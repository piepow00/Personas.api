using MediatR;
using Personas.Application.Commands;
using Personas.Domain.Entities;
using Personas.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Personas.Application.Handlers
{
    public class ActualizarPersonaCommandHandler
    : IRequestHandler<ActualizarPersonaCommand, bool>
    {
        private readonly IPersonaRepository _repository;

        public ActualizarPersonaCommandHandler(IPersonaRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(
            ActualizarPersonaCommand request,
            CancellationToken cancellationToken)
        {
            var persona = await _repository.GetById(request.Id);

            if (persona == null)
                return false;

            persona.ActualizarNombre(request.Nombre);

            if (persona is Medico medico && request.Especialidad != null)
            {
                medico.ActualizarEspecialidad(request.Especialidad);
            }

            await _repository.Update(persona);

            return true;
        }
    }
}
