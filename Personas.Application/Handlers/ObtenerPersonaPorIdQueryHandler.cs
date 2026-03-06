namespace Personas.Application.Handlers
{
    using MediatR;
    using Personas.Application.Dtos;
    using Personas.Application.Queries;
    using Personas.Domain.Entities;
    using Personas.Domain.Enums;
    using Personas.Domain.Interface;
    using System.Threading;
    using System.Threading.Tasks;

    public class ObtenerPersonaPorIdQueryHandler
        : IRequestHandler<ObtenerPersonaPorIdQuery, PersonaDto>
    {
        private readonly IPersonaRepository _repository;

        public ObtenerPersonaPorIdQueryHandler(IPersonaRepository repository)
        {
            _repository = repository;
        }

        public async Task<PersonaDto> Handle(
            ObtenerPersonaPorIdQuery request,
            CancellationToken cancellationToken)
        {
            var persona = await _repository.GetById(request.Id);

            if (persona == null)
                return null;
            var result = new PersonaDto
            {
                Id = persona.Id,
                Documento = persona.Documento,
                Nombre = persona.Nombre,
                TipoPersona = persona.TipoPersona
            };
            if (persona.TipoPersona == TipoPersona.Paciente)
            {
                result.FechaNacimiento = (persona as Paciente).FechaNacimiento.ToString("dd/MM/yyyy");
            }
            else
            {
                result.Especialidad = (persona as Medico).Especialidad;
            }

            return result;
        }
    }
}
