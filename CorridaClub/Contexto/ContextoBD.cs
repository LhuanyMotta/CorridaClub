using CorridaClub.Models;
using Microsoft.EntityFrameworkCore;

namespace CorridaClub.Contexto
{
    public class ContextoBD : DbContext
    {
        public ContextoBD(DbContextOptions<ContextoBD> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}