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

        public async Task Inscrever(Inscricao inscricao)
        {
            await _context.Inscricoes.AddAsync(inscricao);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Inscricao>> ListarInscricoesPorEvento(int eventoId)
        {
            return await _context.Inscricoes
                .Where(i => i.EventoId == eventoId)
                .Include(i => i.Usuario)
                .ToListAsync();
        }

        public async Task CancelarInscricao(int inscricaoId)
        {
            var inscricao = await _context.Inscricoes.FindAsync(inscricaoId);
            if (inscricao != null)
            {
                inscricao.Status = "Cancelada";
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Inscricao>> ListarTodasInscricoes()
        {
            return await _context.Inscricoes
                .Include(i => i.Evento)
                .Include(i => i.Usuario)
                .OrderByDescending(i => i.DataInscricao)
                .ToListAsync();
        }
    }
}