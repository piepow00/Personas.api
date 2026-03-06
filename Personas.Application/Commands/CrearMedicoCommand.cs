

using MediatR;

namespace Personas.Application.Commands
{

    public class CrearMedicoCommand : IRequest<int>
    {
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public string Especialidad { get; set; }
    }
}
