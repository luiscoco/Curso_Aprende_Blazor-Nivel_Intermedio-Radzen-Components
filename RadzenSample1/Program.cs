using Radzen;
using RadzenSample1.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); // Modo interactivo en el servidor

builder.Services.AddRadzenComponents();

var app = builder.Build();

// Configuración del middleware.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Mapeo de Razor Components con el modo interactivo del servidor
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();  // Solo modo interactivo en servidor

app.Run();
