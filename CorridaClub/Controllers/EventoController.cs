using CorridaClub.Contexto;
using CorridaClub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorridaClub.Controllers
{
    public class EventoController : Controller
    {
        private readonly ContextoBD _context;

        public EventoController(ContextoBD context)
        {
            _context = context;
        }

        public async Task Adicionar(Evento evento)
        {
            await _context.Eventos.AddAsync(evento);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Evento>> ListarEventos()
        {
            return await _context.Eventos
                .Include(e => e.Inscricoes)
                .ThenInclude(i => i.Usuario)
                .ToListAsync();
        }

        public async Task<List<Evento>> ListarProximosEventos()
        {
            return await _context.Eventos
                .Where(e => e.Data >= DateTime.Now)
                .OrderBy(e => e.Data)
                .ToListAsync();
        }

        public async Task<Evento?> ObterPorId(int id)
        {
            return await _context.Eventos
                .Include(e => e.Inscricoes)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Atualizar(Evento evento)
        {
            
            _context.Eventos.Update(evento);
            await _context.SaveChangesAsync();
        }
    }
}