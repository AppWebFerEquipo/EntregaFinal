using System.Collections.Generic;
using System.Linq;
using FindingApp.Infrastructure.Data;
using FindingApp.Domain.Entities;
using FindingApp.Domain.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace FindingApp.Infrastructure.Repositories
{
    public class TorneosSqlRepository : ITorneosRepository
    {
        private readonly proyectoIntegradorContext _context;

        public TorneosSqlRepository(proyectoIntegradorContext context)
        {
            this._context = context;
        }

        public async Task<IQueryable<TblTournament>> GetAll()
        {
            //Origen|Colección Método Iterador
            var query = await _context.TblTournaments.AsQueryable<TblTournament>().AsNoTracking().ToListAsync();
            return query.AsQueryable();
        }

        public async Task<TblTournament> GetById(int id)
        {     
            var query = await _context.TblTournaments.FindAsync(id);       
            //var query = await _context.TblTournaments.Include(x => x.Disciplina).FirstOrDefaultAsync(x => x.Id == id);
            return query;

            /* var query = await _context.People.AsQueryable().Join(_context.Addresses, 
            p => p.Id,
            a => a.PersonId,
            (p, a) => new Person {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                Age = p.Age,
                Gender = p.Gender,
                Job = p.Job,
                Address = a   
            }
            ).FirstOrDefaultAsync(x => x.Id == id); 

            return query;*/
        }

        public bool Exist(Expression<Func<TblTournament, bool>> expression)
        {
            return _context.TblTournaments.Any(expression);
        }
        public async Task<IQueryable<TblTournament>> GetByFilter(TblTournament torneo)
        {
            if(torneo == null)
                return new List<TblTournament>().AsQueryable();

            var query = _context.TblTournaments.AsQueryable();

            if(!string.IsNullOrEmpty(torneo.Disciplina))
                query = query.Where(x => x.Disciplina.Contains(torneo.Disciplina));

            if(!string.IsNullOrEmpty(torneo.CostoIns))
                query = query.Where(x => x.CostoIns == torneo.CostoIns);

            if(torneo.Tipo != null)
                query = query.Where(x => x.Tipo == torneo.Tipo);

            var result = await query.ToListAsync();

            return result.AsQueryable().AsNoTracking();
        }  
    
        public async Task<int> Create(TblTournament torneo)
        {
            var entity = torneo;
            await _context.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();

            if(rows <= 0)
                throw new Exception("No fue posible realizar el registro...");

            return entity.Id;
        }

        public async Task<bool> Update(int id, TblTournament torneo)
        {
            if(id <= 0 || torneo == null)
                throw new ArgumentException("Falta información para continuar con el proceso de modificación...");

            var entity = await GetById(id);

            entity.Disciplina = torneo.Disciplina;
            entity.CantidadEquipo = torneo.CantidadEquipo;
            entity.Lugares = torneo.Lugares;
            entity.CostoIns = torneo.CostoIns;
            entity.Bases = torneo.Bases;
            entity.NumRondas = torneo.NumRondas;
            entity.Tipo = torneo.Tipo;

            _context.Update(entity);

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        
    }
}