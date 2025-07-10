using CorridaClub.Components;
using CorridaClub.Components.Account;
using CorridaClub.Contexto;
using CorridaClub.Controllers;
using CorridaClub.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// String de conexão
var connectionString = builder.Configuration.GetConnectionString("BaseConexaoMySql");

// Contexto do Identity
builder.Services.AddDbContext<CorridaClubContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Contexto personalizado (para controllers)
builder.Services.AddDbContext<ContextoBD>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Registro dos controllers
builder.Services.AddScoped<UsuarioController>();
builder.Services.AddScoped<EventoController>();
builder.Services.AddScoped<InscricaoController>();
builder.Services.AddScoped<PedidoController>();

// Configuração do Identity
builder.Services.AddIdentityCore<CorridaClubUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
})
    .AddEntityFrameworkStores<CorridaClubContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

// Autenticação com cookies
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

// Blazor Authentication support
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

// Email (fake, apenas para testes)
builder.Services.AddSingleton<IEmailSender<CorridaClubUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

// Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Auth
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Endpoints do Identity (login, logout, etc.)
app.MapAdditionalIdentityEndpoints();

app.Run();
