using System.Security.Claims;
using CorridaClub.Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace CorridaClub.Services
{


    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal anonymous = new(new ClaimsIdentity());
        private ClaimsPrincipal currentUser = null;

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var state = new AuthenticationState(currentUser ?? anonymous);
            return Task.FromResult(state);
        }

        public Task MarkUserAsAuthenticated(Usuario usuario)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.TipoMembro)
            }, "CorridaClubAuth");

            currentUser = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

            return Task.CompletedTask;
        }

        public Task Logout()
        {
            currentUser = null;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return Task.CompletedTask;
        }
    }
}