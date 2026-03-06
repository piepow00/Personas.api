using MediatR;
using Personas.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Application.Queries
{
    public class ObtenerPersonaPorIdQuery : IRequest<PersonaDto>
    {
        public int Id { get; set; }
    }
}
