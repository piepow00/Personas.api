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
    public class CrearPacienteHandler : IRequestHandler<CrearPacienteCommand, int>
    {
        private readonly IPersonaRepository _repository;

        public CrearPacienteHandler(IPersonaRepository repository)
        {
            _repository = repository;
        }

        public Task<int> Handle(CrearPacienteCommand request, CancellationToken cancellationToken)
        {
            var paciente = new Paciente(request.Nombre, request.Documento, request.FechaNacimiento);

            _repository.Add(paciente);
            _repository.Save();

            return Task.FromResult(paciente.Id);
        }
    }
}
