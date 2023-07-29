using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class EventoPersist : IEventoPersist
    {
        public ProEventosContext _context { get; }

        public EventoPersist(ProEventosContext context)
        {
            this._context = context;
            
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedeSociais);

            if(includePalestrantes)
            {
                query = query
                .Include(e => e.PalestranteEventos)
                .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedeSociais);

            if(includePalestrantes)
            {
                query = query
                .Include(e => e.PalestranteEventos)
                .ThenInclude(pe => pe.Palestrante);
            }
            
            query = query.OrderBy(e => e.Id)
                         .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes)
        {
             IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedeSociais);

            if(includePalestrantes)
            {
                query = query
                .Include(e => e.PalestranteEventos)
                .ThenInclude(pe => pe.Palestrante);
            }
            
            query = query.OrderBy(e => e.Id)
                         .Where(e => e.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

    }
}