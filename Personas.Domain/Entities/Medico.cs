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
        public static Medico Crear(string nombre, string documento, string especialidad)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(documento))
                throw new ArgumentException("El documento no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(especialidad))
                throw new ArgumentException("La especialidad no puede estar vacía.");
            return new Medico(nombre, documento, especialidad);
        }
    }
}
