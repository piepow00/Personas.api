using Personas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Infrastructure
{
    public class PersonasDbContext : DbContext
    {
        public PersonasDbContext() : base("PersonasDb")
        {
        }

        public DbSet<Persona> Personas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>()
                .Map<Medico>(m => m.Requires("Discriminator").HasValue("Medico"))
                .Map<Paciente>(m => m.Requires("Discriminator").HasValue("Paciente"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
