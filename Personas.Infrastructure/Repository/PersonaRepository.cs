using Personas.Domain.Entities;
using Personas.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Infrastructure.Repository
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly PersonasDbContext _context;

        public PersonaRepository(PersonasDbContext context)
        {
            _context = context;
        }

        public void Add(Persona persona)
        {
            _context.Personas.Add(persona);
        }

        public async Task<IEnumerable<Persona>> GetAll()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task<Persona> GetById(int id)
        {
            return await _context.Personas.FindAsync(id);

        }

        public async Task Update(Persona persona)
        {
            _context.Entry(persona).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var persona = _context.Personas.Find(id);
            if (persona != null)
                _context.Personas.Remove(persona);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
