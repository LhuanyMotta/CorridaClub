using CorridaClub.Contexto;
using CorridaClub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorridaClub.Controllers
{
    public class InscricaoController : Controller
    {
        private readonly ContextoBD _context;

        public InscricaoController(ContextoBD context)
        {
            _context = context;
        }

        // Adiciona uma nova inscrição
        public async Task Inscrever(Inscricao inscricao)
        {
            await _context.Inscricoes.AddAsync(inscricao);
            await _context.SaveChangesAsync();
        }

        // Lista inscrições de um evento específico, incluindo dados do usuário
        public async Task<List<Inscricao>> ListarInscricoesPorEvento(int eventoId)
        {
            return await _context.Inscricoes
                .Where(i => i.EventoId == eventoId)
                .Include(i => i.Usuario!) // Adiciona ! se houver aviso de nulabilidade
                .ToListAsync();
        }

        // Cancela uma inscrição (altera o status)
        public async Task CancelarInscricao(int inscricaoId)
        {
            var inscricao = await _context.Inscricoes.FindAsync(inscricaoId);
            if (inscricao != null)
            {
                inscricao.Status = "Cancelada";
                await _context.SaveChangesAsync();
            }
        }
    }
}
