using Core.Service;
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Org.BouncyCastle.Security;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
    [TestClass()]
    public class ComponenteServiceTests
    {
        private ModernSchoolContext _context;
        private IComponenteService _componenteService;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<ModernSchoolContext>();
            builder.UseInMemoryDatabase("ModernSchool");
            var options = builder.Options;

            _context = new ModernSchoolContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var componentes = new List<Componente>
                {
                    new Componente { Id = 1, Nome = "Matemática"},
                    new Componente { Id = 2, Nome = "Filosofia"},
                    new Componente { Id = 3, Nome = "Sociologia"},
                };

            _context.AddRange(componentes);
            _context.SaveChanges();

            _componenteService = new ComponenteService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _componenteService.Create(new Componente() { Id = 4, Nome = "Português" });
            // Assert
            Assert.AreEqual(4, _componenteService.GetAll().Count());
            var componente = _componenteService.Get(4);
            Assert.AreEqual(4, componente.Id);
            Assert.AreEqual("Português", componente.Nome);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            _componenteService.Delete(3);
            // Assert
            Assert.AreEqual(2, _componenteService.GetAll().Count());
            var componente = _componenteService.Get(3);
            Assert.AreEqual(null, componente);
        }

        [TestMethod()]
        public void EditTest()
        {
            var componente = _componenteService.Get(1);
            componente.Id = 1;
            componente.Nome = "Matemática";
            _componenteService.Edit(componente);
            //Assert
            componente = _componenteService.Get(1);
            Assert.IsNotNull(componente);
            Assert.AreEqual(1, componente.Id);
            Assert.AreEqual("Matemática", componente.Nome);
        }

        [TestMethod()]
        public void GetTest()
        {
            var componente = _componenteService.Get(2);
            Assert.IsNotNull(componente);
            Assert.AreEqual(2, componente.Id);
            Assert.AreEqual("Filosofia", componente.Nome);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaComponente = _componenteService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaComponente, typeof(IEnumerable<Componente>));
            Assert.IsNotNull(listaComponente);
            Assert.AreEqual(3, listaComponente.Count());
            Assert.AreEqual(2, listaComponente.First().Id);
        }
    }
}