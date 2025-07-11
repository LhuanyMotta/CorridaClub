using CorridaClub.Contexto;
using CorridaClub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorridaClub.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ContextoBD _context;

        public PedidoController(ContextoBD context)
        {
            _context = context;
        }

        public async Task AdicionarPedido(Pedido pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Pedido>> ListarPedidosPorUsuario(int usuarioId)
        {
            return await _context.Pedidos
                .Where(p => p.UsuarioId == usuarioId)
                .ToListAsync();
        }

        public async Task AtualizarStatusPedido(int pedidoId, string novoStatus)
        {
            var pedido = await _context.Pedidos.FindAsync(pedidoId);
            if (pedido != null)
            {
                pedido.Status = novoStatus;
                await _context.SaveChangesAsync();
            }
        }
    }
}