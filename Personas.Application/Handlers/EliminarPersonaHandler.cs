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
    public class EliminarPersonaHandler : IRequestHandler<EliminarPersonaCommand, string>
    {
        private readonly IPersonaRepository _repository;

        public EliminarPersonaHandler(IPersonaRepository repository)
        {
            _repository = repository;
        }

        public Task<string> Handle(EliminarPersonaCommand request, CancellationToken cancellationToken)
        {
            _repository.Delete(request.Id);
            _repository.Save();

            return Task.FromResult("Registro Eliminado");
        }
    }
}
