# How to install Radzen Components in your Blazor Web Application

**Note:** For more information about this sample visit this URL: https://blazor.radzen.com/get-started?theme=material3

![image](https://github.com/user-attachments/assets/b6c353f3-fc02-49d7-8dcd-d99b454cd089)

## 1. Load the Nuget package 

![image](https://github.com/user-attachments/assets/9975d157-5973-4f5f-b2e8-313d0314c458)

## 2. Modify the App.razor component to include the Radzen references

Add this line in the head:

```
<RadzenTheme Theme="material" @rendermode="InteractiveServer" />
```

Also include in the body the following code:

```
<script src="_content/Radzen.Blazor/Radzen.Blazor.js?v=@(typeof(Radzen.Colors).Assembly.GetName().Version)"></script>
```

This is the **App.razor** component including Radzen Components

```html
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <base href="/" />
    <link rel="stylesheet" href="bootstrap/bootstrap.min.css" />
    <link rel="stylesheet" href="app.css" />
    <link rel="stylesheet" href="RadzenSample1.styles.css" />
    <RadzenTheme Theme="material" @rendermode="InteractiveServer" />
    <link rel="icon" type="image/png" href="favicon.png" />
    <HeadOutlet @rendermode="InteractiveServer" />
</head>

<body>
    <Routes @rendermode="InteractiveServer" />
    <script src="_framework/blazor.web.js"></script>
    <script src="_content/Radzen.Blazor/Radzen.Blazor.js?v=@(typeof(Radzen.Colors).Assembly.GetName().Version)"></script>
</body>

</html>
```

## 3. Include in the _Imports.razor the Radzen.Blazor

```razor
@using System.Net.Http
@using System.Net.Http.Json
@using Microsoft.AspNetCore.Components.Forms
@using Microsoft.AspNetCore.Components.Routing
@using Microsoft.AspNetCore.Components.Web
@using static Microsoft.AspNetCore.Components.Web.RenderMode
@using Microsoft.AspNetCore.Components.Web.Virtualization
@using Microsoft.JSInterop
@using RadzenSample1
@using RadzenSample1.Components
@using Radzen
@using Radzen.Blazor
```

## 4. Modify the middleware(program.cs)

Include the following line in the **program.cs**:

```
builder.Services.AddRadzenComponents();
```

This is the whole **program.cs** file:

```csharp
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
```

## 5. Create a new Razor Component to validate the Radzen installation

We create a new component doing right click on the **Pages** folder and selecting **Add->Razor Component**:

![image](https://github.com/user-attachments/assets/37933abb-c0e6-4d84-afcc-19d531a4ff94)

We set the new Razor Component name: **RadzenButtons.razor**

```razor
@page "/radzen-buttons"
@inject NotificationService NotificationService


@* https://blazor.radzen.com/button?theme=material3 *@

<RadzenButton Click="@ButtonClicked" Text="Hi"></RadzenButton>

<br />
<br />

<p>@message</p>

<br />
<br />

<RadzenStack Orientation="Orientation.Horizontal" AlignItems="AlignItems.Center" Gap="1rem" Wrap="FlexWrap.Wrap">
    <RadzenButton Click=@(args => OnClick("Primary button")) Text="Primary" ButtonStyle="ButtonStyle.Primary" />
    <RadzenButton Click=@(args => OnClick("Secondary button")) Text="Secondary" ButtonStyle="ButtonStyle.Secondary" />
    <RadzenButton Click=@(args => OnClick("Base button")) Text="Base" ButtonStyle="ButtonStyle.Base" />
    <RadzenButton Click=@(args => OnClick("Info button")) Text="Info" ButtonStyle="ButtonStyle.Info" />
    <RadzenButton Click=@(args => OnClick("Success button ")) Text="Success" ButtonStyle="ButtonStyle.Success" />
    <RadzenButton Click=@(args => OnClick("Warning button ")) Text="Warning" ButtonStyle="ButtonStyle.Warning" />
    <RadzenButton Click=@(args => OnClick("Danger button")) Text="Danger" ButtonStyle="ButtonStyle.Danger" />
</RadzenStack>

@code {
    private string message = "";

    void ButtonClicked()
    {
        message = "Hello World!";
    }
    private void OnClick(string text)
    {
        NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Info, Summary = "Button Clicked", Detail = text });
    }

}
```

## 6. Modify the NavMenu.razor component and add a new NavLink

Add a new NavLink in the NavMenu.razor component to navigate to the new component:

```
<div class="nav-item px-3">
   <NavLink class="nav-link" href="radzen-buttons">
       <span class="bi bi-list-nested-nav-menu" aria-hidden="true"></span> RadzenButtons
   </NavLink>
</div>
```

## 7. Run the application to validate the result

![image](https://github.com/user-attachments/assets/1149cf90-4b85-446a-a16d-4e16a2413a06)
