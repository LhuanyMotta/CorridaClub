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

        // Adiciona um novo evento
        public async Task Adicionar(Evento evento)
        {
            await _context.Eventos.AddAsync(evento);
            await _context.SaveChangesAsync();
        }

        // Lista todos os eventos, incluindo inscrições e usuários relacionados
        public async Task<List<Evento>> ListarEventos()
        {
            return await _context.Eventos
                .Include(e => e.Inscricoes!)
                .ThenInclude(i => i.Usuario!)
                .ToListAsync();
        }

        // Lista apenas eventos futuros
        public async Task<List<Evento>> ListarProximosEventos()
        {
            return await _context.Eventos
                .Where(e => e.Data >= DateTime.Now)
                .OrderBy(e => e.Data)
                .ToListAsync();
        }

        // Busca um evento por ID, incluindo as inscrições
        public async Task<Evento?> ObterPorId(int id)
        {
            return await _context.Eventos
                .Include(e => e.Inscricoes!)
                .ThenInclude(i => i.Usuario!)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
