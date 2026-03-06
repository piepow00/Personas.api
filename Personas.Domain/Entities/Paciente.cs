using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personas.Domain.Enums;

namespace Personas.Domain.Entities
{
    public class Paciente : Persona
    {
        public DateTime FechaNacimiento { get; set; }
        protected Paciente()
        {
            
        }
        public Paciente(string nombre, string documento, DateTime fechaNacimiento)
            : base(nombre, documento, TipoPersona.Paciente)
        {
            FechaNacimiento = fechaNacimiento;
        }
    }
}
