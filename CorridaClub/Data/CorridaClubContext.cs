using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CorridaClub.Models;

namespace CorridaClub.Data
{
    public class CorridaClubContext : IdentityDbContext<CorridaClubUser>
    {
        public CorridaClubContext(DbContextOptions<CorridaClubContext> options)
            : base(options)
        {
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
