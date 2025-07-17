using CorridaClub.Components;
using CorridaClub.Contexto;
using CorridaClub.Controllers;
using CorridaClub.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Registrar o CustomAuthStateProvider
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => 
    provider.GetRequiredService<CustomAuthStateProvider>());

// Registrar outros serviços necessários
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddProtectedBrowserStorage();

// Configura��o do DbContext
var connectionString = builder.Configuration.GetConnectionString("BaseConexaoMySql");

builder.Services.AddDbContext<ContextoBD>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
           .LogTo(Console.WriteLine, LogLevel.Information)
           .EnableSensitiveDataLogging();
});

// Register controllers
builder.Services.AddScoped<UsuarioController>();
builder.Services.AddScoped<EventoController>();
builder.Services.AddScoped<InscricaoController>();
builder.Services.AddScoped<PedidoController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();