using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace CorridaClub.Providers
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;

        public CustomAuthStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var usuarioId = await _sessionStorage.GetAsync<int>("UsuarioId");
                var usuarioNome = await _sessionStorage.GetAsync<string>("UsuarioNome");

                if (usuarioId.Success && usuarioId.Value > 0)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuarioId.Value.ToString()),
                        new Claim(ClaimTypes.Name, usuarioNome.Success ? usuarioNome.Value : "")
                    };

                    var identity = new ClaimsIdentity(claims, "custom");
                    return new AuthenticationState(new ClaimsPrincipal(identity));
                }

                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro em GetAuthenticationStateAsync: {ex}");
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }

        public async Task UpdateAuthenticationState(int usuarioId, string usuarioNome)
        {
            await _sessionStorage.SetAsync("UsuarioId", usuarioId);
            await _sessionStorage.SetAsync("UsuarioNome", usuarioNome);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task Logout()
        {
            await _sessionStorage.DeleteAsync("UsuarioId");
            await _sessionStorage.DeleteAsync("UsuarioNome");
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}