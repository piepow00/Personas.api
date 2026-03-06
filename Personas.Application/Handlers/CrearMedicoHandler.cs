using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Personas.Application.Commands;
using Personas.Domain;
using Personas.Domain.Entities;
using Personas.Domain.Interface;
using System.Threading;

namespace Personas.Application.Handlers
{

    public class CrearMedicoHandler : IRequestHandler<CrearMedicoCommand, int>
    {
        private readonly IPersonaRepository _repository;

        public CrearMedicoHandler(IPersonaRepository repository)
        {
            _repository = repository;
        }

        public Task<int> Handle(CrearMedicoCommand request, CancellationToken cancellationToken)
        {
            var medico = new Medico(request.Nombre, request.Documento, request.Especialidad);

            _repository.Add(medico);
            _repository.Save();

            return Task.FromResult(medico.Id);
        }
    }
}
