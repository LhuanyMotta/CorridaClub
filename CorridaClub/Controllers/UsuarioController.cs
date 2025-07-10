using CorridaClub.Contexto;
using CorridaClub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorridaClub.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ContextoBD _context;

        public UsuarioController(ContextoBD context)
        {
            _context = context;
        }

        public async Task Adicionar(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Usuario>> ListarUsuarios()
        {
            return await _context.Usuarios
                .Include(u => u.Inscricoes!)
                .Include(u => u.Pedidos!)
                .ToListAsync();
        }

        public async Task<Usuario?> ObterPorId(int id)
        {
            return await _context.Usuarios
                .Include(u => u.Inscricoes!)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task Atualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
