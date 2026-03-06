using Personas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Domain.Interface
{
    public interface IPersonaRepository
    {
        void Add(Persona persona);
        Task<Persona> GetById(int id);
        Task<IEnumerable<Persona>> GetAll();
        Task Update(Persona persona);
        void Delete(int id);
        void Save();
    }
}
