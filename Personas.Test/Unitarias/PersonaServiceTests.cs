using FluentAssertions;
using Moq;
using Personas.Domain.Entities;
using Personas.Domain.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Personas.Test.Unitarias
{
    public class PersonaRepositoryTestsBase
    {
        protected IPersonaRepository CreateRepository()
        {
            var mockRepo = new Mock<IPersonaRepository>();
            List<Persona> personas = new List<Persona>();
            var persona = Medico.Crear("Andres", "1045741571", "Med General");
            var persona2 = Medico.Crear("Antonio", "33286002", "Odontologo");
            personas.Add(persona);
            personas.Add(persona2);
            IEnumerable<Persona> setup = personas;
            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(setup);
            mockRepo.Setup(r => r.GetById(0)).ReturnsAsync(persona);
            return mockRepo.Object;
        }

        protected Persona CrearMedico(string nombre = "Andres", string documento = "1045741571", string especialidad = "Med General")
        {
            return Medico.Crear(nombre, documento, especialidad);
        }

        [Fact]
        public async Task GetById_ShouldReturnNull_WhenNotExists()
        {
            var repo = CreateRepository();
            var persona = await repo.GetById(-1);
            persona.Should().BeNull();
        }

        [Fact]
        public async Task AddAndGetAll_ShouldContainAddedPersona()
        {
            var repo = CreateRepository();
            var p = CrearMedico();
            repo.Add(p);
            repo.Save();

            var all = (await repo.GetAll()).ToList();
            all.Should().NotBeEmpty();
            all.Should().Contain(x => x.Nombre.Equals("Andres", StringComparison.OrdinalIgnoreCase)
                                      || x.Documento == "1045741571");
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllAdded()
        {
            var repo = CreateRepository();
            repo.Add(CrearMedico("Andres", "1045741571", "Med General"));
            repo.Add(CrearMedico("Antonio", "33286002", "Odontologo"));
            repo.Save();

            var all = (await repo.GetAll()).ToList();
            all.Count.Should().BeGreaterThanOrEqualTo(2);
            all.Select(x => x.Documento).Should().Contain(new[] { "1045741571", "33286002" });
        }

        [Fact]
        public async Task Update_ShouldPersistChanges()
        {
            var repo = CreateRepository();
            var p = CrearMedico("Andres", "1045741571", "Med General");
            repo.Add(p);
            repo.Save();

            var stored = (await repo.GetAll()).FirstOrDefault();
            stored.Should().NotBeNull();

            stored.ActualizarNombre("X-Modificado");
            await repo.Update(stored);
            repo.Save();

            var fetched = await repo.GetById(stored.Id);
            fetched.Should().NotBeNull();
            fetched.Nombre.Should().Be("X-Modificado");
        }


        [Fact]
        public void Save_ShouldNotThrow()
        {
            var repo = CreateRepository();
            Action act = () => repo.Save();
            act.Should().NotThrow();
        }
    }
}
