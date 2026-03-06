using Personas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Application.Dtos
{
    public class PersonaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public string Especialidad { get; set; }
        public string FechaNacimiento { get; set; }
        public TipoPersona TipoPersona { get; set; }
    }
}
