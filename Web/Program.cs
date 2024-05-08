var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

services
    .AddOutputCache();

services
    .AddHttpClient<WeatherApiClient>(client =>
        // This URL uses "https+http://" to indicate HTTPS is preferred over HTTP.
        // // Learn more about service discovery scheme resolution at https://aka.ms/dotnet/sdschemes.
        client.BaseAddress = new("https+http://apiservice")
    );

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseOutputCache();

app
    .MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();

app.Run();
