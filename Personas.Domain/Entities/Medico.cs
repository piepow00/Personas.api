using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personas.Domain.Enums;

namespace Personas.Domain.Entities
{
    public class Medico : Persona
    {
        public string Especialidad { get; set; }

        protected Medico()
        {

        }
        public Medico(string nombre, string documento, string especialidad)
            : base(nombre, documento, TipoPersona.Medico)
        {
            Especialidad = especialidad;
        }
    }
}
