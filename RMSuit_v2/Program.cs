using PruebaConBlazor.Constants;
using RMSuit_v2.Components;
using RMSuit_v2.Services.Camareros;
using RMSuit_v2.Services.Dibujos;
using RMSuit_v2.Services.Empleados;
using RMSuit_v2.Services.Salones;
using RMSuit_v2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configure HttpClient for dependency injection
builder.Services.AddHttpClient();

// Registramos los servicios específicos
builder.Services.AddScoped<CamarerosService>();
builder.Services.AddScoped<EmpleadosService>();
builder.Services.AddScoped<DibujosService>();
builder.Services.AddScoped<SalonesService>();

// Registramos ApiService que utiliza los servicios específicos
builder.Services.AddScoped<ApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
