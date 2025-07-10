using Microsoft.AspNetCore.Identity;
using System;

namespace CorridaClub.Data
{
    public class CorridaClubUser : IdentityUser
    {
        public string? Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Genero { get; set; }
        public string? Telefone { get; set; }
        public string? TipoMembro { get; set; }
    }
}
