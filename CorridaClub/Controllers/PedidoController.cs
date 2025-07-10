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

        // Adiciona um novo pedido ao banco
        public async Task AdicionarPedido(Pedido pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();
        }

        // Lista pedidos de um usuário específico
        public async Task<List<Pedido>> ListarPedidosPorUsuario(int usuarioId)
        {
            return await _context.Pedidos
                .Where(p => p.UsuarioId == usuarioId)
                //.Include(p => p.Usuario!) // Descomente se houver navegação para Usuario
                .ToListAsync();
        }

        // Atualiza o status de um pedido
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
