using MediatR;
using Personas.Application.Commands;
using Personas.Application.Dtos;
using Personas.Application.Handlers;
using Personas.Application.Queries;
using Personas.Domain.Interface;
using Personas.Infrastructure;
using Personas.Infrastructure.Repository;
using System.Collections.Generic;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

public static class UnityConfig
{
    public static void Register(HttpConfiguration config)
    {
        var container = new UnityContainer();

        #region DbContext
        container.RegisterType<PersonasDbContext>(
            new HierarchicalLifetimeManager());
        #endregion
        #region Repository
        container.RegisterType<IPersonaRepository, PersonaRepository>(
            new HierarchicalLifetimeManager());
        #endregion

        #region Handler
        container.RegisterType<
            IRequestHandler<CrearMedicoCommand, int>,
            CrearMedicoHandler>();

        container.RegisterType<
            IRequestHandler<CrearPacienteCommand, int>,
            CrearPacienteHandler>();

        container.RegisterType<
            IRequestHandler<EliminarPersonaCommand, string>,
            EliminarPersonaHandler>();

        container.RegisterType<
           IRequestHandler<ActualizarPersonaCommand, bool>,
           ActualizarPersonaCommandHandler>();

        container.RegisterType<
            IRequestHandler<ObtenerPersonaPorIdQuery, PersonaDto>,
            ObtenerPersonaPorIdQueryHandler>();

        container.RegisterType<
            IRequestHandler<ObtenerPersonasQuery, List<PersonaDto>>,
            ObtenerPersonasQueryHandler>();

        #endregion

        #region MediatR
        container.RegisterType<IMediator, Mediator>();
        #endregion

        container.RegisterFactory<ServiceFactory>(c =>
            new ServiceFactory(t => c.Resolve(t)));

        config.DependencyResolver =
            new UnityDependencyResolver(container);
    }
}