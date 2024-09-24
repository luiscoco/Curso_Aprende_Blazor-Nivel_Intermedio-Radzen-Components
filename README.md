# How to install Radzen Components in your Blazor Web Application

**Note:** For more information about this sample visit this URL: https://blazor.radzen.com/get-started?theme=material3

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


3. 
