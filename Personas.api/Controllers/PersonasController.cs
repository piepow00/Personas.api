using MediatR;
using Personas.api.Infrastructure;
using Personas.Application.Commands;
using Personas.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Personas.api.Controllers
{
    [RoutePrefix("api/personas")]
    public class PersonasController : ApiController
    {
        private readonly IMediator _mediator;

        public PersonasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CrearMedico")]
        public async Task<IHttpActionResult> CrearMedico(CrearMedicoCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpPost]
        [Route("CrearPaciente")]
        public async Task<IHttpActionResult> CrearPaciente(CrearPacienteCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> ObtenerPersona(int id)
        {
            var result = await _mediator.Send(
                new ObtenerPersonaPorIdQuery { Id = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("ObtenerPersonas")]
        public async Task<IHttpActionResult> ObtenerPersonas()
        {
            var result = await _mediator.Send(
                new ObtenerPersonasQuery { });

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete]
        [Route("EliminarByid")]
        public async Task<IHttpActionResult> EliminarPersona(EliminarPersonaCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpPut]
        [Route("ActualizarByid")]
        public async Task<IHttpActionResult> Actualizar(int id, ActualizarPersonaCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id no coincide");

            var result = await _mediator.Send(command);

            if (!result)
                return NotFound();

            return Ok(result);
        }
    }
}