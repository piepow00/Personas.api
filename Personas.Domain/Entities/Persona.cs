using Personas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Domain.Entities
{
    public abstract class Persona
    {
        public int Id { get; protected set; }
        public string Nombre { get; protected set; }
        public string Documento { get; protected set; }
        public TipoPersona TipoPersona { get; protected set; }


        protected Persona() { }

        protected Persona(string nombre, string documento, TipoPersona tipo)
        {
            Nombre = nombre;
            Documento = documento;
            TipoPersona = tipo;
        }

        public void ActualizarNombre(string nuevoNombre)
        {
            if (string.IsNullOrWhiteSpace(nuevoNombre))
                throw new ArgumentException("El nombre no puede estar vacío.");
            Nombre = nuevoNombre;
        }

        public void ActualizarEspecialidad(string nuevaEspecialidad)
        {
            if (TipoPersona != TipoPersona.Medico)
                throw new InvalidOperationException("Solo los médicos pueden tener especialidad.");
            if (string.IsNullOrWhiteSpace(nuevaEspecialidad))
                throw new ArgumentException("La especialidad no puede estar vacía.");
            ((Medico)this).Especialidad = nuevaEspecialidad;
        }
    }
}
