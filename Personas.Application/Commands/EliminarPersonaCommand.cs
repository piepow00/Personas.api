using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Application.Commands
{
    public class EliminarPersonaCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
