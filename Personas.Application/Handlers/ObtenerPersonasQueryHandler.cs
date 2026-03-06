using MediatR;
using Personas.Application.Dtos;
using Personas.Application.Queries;
using Personas.Domain.Entities;
using Personas.Domain.Enums;
using Personas.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Personas.Application.Handlers
{
    public class ObtenerPersonasQueryHandler
       : IRequestHandler<ObtenerPersonasQuery, List<PersonaDto>>
    {
        private readonly IPersonaRepository _repository;

        public ObtenerPersonasQueryHandler(IPersonaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PersonaDto>> Handle(
            ObtenerPersonasQuery request,
            CancellationToken cancellationToken)
        {
            var personas = await _repository.GetAll();

            if (personas == null)
                return null;
            var result = personas.Select(p => new PersonaDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Documento = p.Documento,
                TipoPersona = p.TipoPersona,
                Especialidad = p.TipoPersona == TipoPersona.Medico ? (p as Medico)?.Especialidad : null,
                FechaNacimiento = p.TipoPersona == TipoPersona.Paciente ? (p as Paciente)?.FechaNacimiento.ToString("yyyy-MM-dd") : null
            }).ToList();
            return result;
        }
    }
}
