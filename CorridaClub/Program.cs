using CorridaClub.Components;
using CorridaClub.Contexto;
using CorridaClub.Controllers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configuração do DbContext
var connectionString = builder.Configuration.GetConnectionString("BaseConexaoMySql");
builder.Services.AddDbContext<ContextoBD>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

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