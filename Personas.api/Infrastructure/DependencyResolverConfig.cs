using MediatR;
using Personas.Application.Commands;
using Personas.Application.Handlers;
using Personas.Domain.Interface;
using Personas.Infrastructure;
using Personas.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Personas.api.Infrastructure
{
    public static class DependencyResolverConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var services = new Dictionary<Type, Func<object>>();

            services.Add(typeof(PersonasDbContext),
                () => new PersonasDbContext());

            services.Add(typeof(IPersonaRepository),
                () => new PersonaRepository(
                    (PersonasDbContext)services[typeof(PersonasDbContext)]()));

            services.Add(typeof(IRequestHandler<CrearMedicoCommand, int>),
                () => new CrearMedicoHandler(
                    (IPersonaRepository)services[typeof(IPersonaRepository)]()));

            services.Add(typeof(IMediator), () =>
                new Mediator(type =>
                    services.ContainsKey(type)
                        ? services[type]()
                        : null));

            config.DependencyResolver = new SimpleResolver(services);
        }
    }
}