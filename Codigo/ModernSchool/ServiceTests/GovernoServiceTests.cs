using Core.Service;
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
    [TestClass()]
    public class GovernoServiceTests
    {

        private ModernSchoolContext _context;
        private IGovernoService _governoService;
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
            var governos = new List<Governo>
                {
                    new Governo { Id = 1,Municipio = "itabaiana", Estado = "SE", DependenciaAdministrativa = "M"},
                    new Governo { Id = 2,Municipio = "campo do brito", Estado = "SE", DependenciaAdministrativa = "E"},
                    new Governo { Id = 3,Municipio = "macambira", Estado = "SE",DependenciaAdministrativa = "E"},
                };

            _context.AddRange(governos);
            _context.SaveChanges();

            _governoService = new GovernoService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _governoService.Create(new Governo() { Id = 4, Municipio = "itabaiana", Estado = "SE",DependenciaAdministrativa = "M" });
            // Assert
            Assert.AreEqual(4, _governoService.GetAll().Count());
            var governo = _governoService.Get(4);
            Assert.AreEqual(4, governo.Id);
            Assert.AreEqual("itabaiana", governo.Municipio);
            Assert.AreEqual("SE", governo.Estado);
            Assert.AreEqual("M", governo.DependenciaAdministrativa);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            _governoService.Delete(2);
            // Assert
            Assert.AreEqual(2, _governoService.GetAll().Count());
            var governo = _governoService.Get(2);
            Assert.AreEqual(null, governo);
        }

        [TestMethod()]
        public void EditTest()
        {
            var governo = _governoService.Get(3);
            governo.Id = 3;
            governo.Municipio = "sao domingos";
            governo.Estado = "SE";
            governo.DependenciaAdministrativa = "E";
            //Assert
            governo = _governoService.Get(3);
            Assert.IsNotNull(governo);
            Assert.AreEqual(3, governo.Id);
            Assert.AreEqual("sao domingos" , governo.Municipio);
            Assert.AreEqual("SE",governo.Estado);
            Assert.AreEqual("E",governo.DependenciaAdministrativa);
        }

        [TestMethod()]
        public void GetTest()
        {
            var governo = _governoService.Get(2);
            Assert.IsNotNull(governo);
            Assert.AreEqual(2, governo.Id);
            Assert.AreEqual("campo do brito", governo.Municipio);
            Assert.AreEqual("SE", governo.Estado);
            Assert.AreEqual("E", governo.DependenciaAdministrativa);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaGoverno = _governoService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaGoverno, typeof(IEnumerable<Governo>));
            Assert.IsNotNull(listaGoverno);
            Assert.AreEqual(3, listaGoverno.Count());
            Assert.AreEqual(1, listaGoverno.First().Id);
        }
    }
}