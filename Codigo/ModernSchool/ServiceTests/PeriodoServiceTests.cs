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
    public class PeriodoServiceTests
    {
        private ModernSchoolContext _context;
        private IPeriodoService _periodoService;
        private object _periodoServicee;

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
            var periodo = new List<Periodo>
                {
                    new Periodo { Id = 1, Nome = "Sexto", DataInicio = DateTime.Parse("2022-01-01"), DataFim = DateTime.Parse("2022-12-12"), AnoLetivo1 = 2022},
                    new Periodo { Id = 2, Nome = "Quarto", DataInicio = DateTime.Parse("2021-01-01"), DataFim = DateTime.Parse("2021-12-12"), AnoLetivo1 = 2021},
                    new Periodo { Id = 3, Nome = "Segundo", DataInicio = DateTime.Parse("2020-01-01"), DataFim = DateTime.Parse("2020-12-12"), AnoLetivo1 = 2020},
                };

            _context.AddRange(periodo);
            _context.SaveChanges();

            _periodoService = new PeriodoService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _periodoService.Create(new Periodo() { Id = 4, Nome = "Segundo", DataInicio = DateTime.Parse("2020-01-01"), DataFim = DateTime.Parse("2020-12-12"), AnoLetivo1 = 2024 });
            // Assert
            Assert.AreEqual(4, _periodoService.GetAll().Count());
            var periodo = _periodoService.Get(4);
            Assert.AreEqual(4, periodo.Id);
            Assert.AreEqual(2024, periodo.AnoLetivo1);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            _periodoService.Delete(3);
            // Assert
            Assert.AreEqual(2, _periodoService.GetAll().Count());
            var periodo = _periodoService.Get(3);
            Assert.AreEqual(null, periodo);
        }

        [TestMethod()]
        public void EditTest()
        {
            var periodo = _periodoService.Get(1);
            periodo.Id = 1;
            periodo.AnoLetivo1 = 2022;
            _periodoService.Edit(periodo);
            //Assert
            periodo = _periodoService.Get(1);
            Assert.IsNotNull(periodo);
            Assert.AreEqual(1, periodo.Id);
            Assert.AreEqual(2022, periodo.AnoLetivo1);
        }

        [TestMethod()]
        public void GetTest()
        {
            var periodo = _periodoService.Get(2);
            Assert.IsNotNull(periodo);
            Assert.AreEqual(2, periodo.Id);
            Assert.AreEqual(2021, periodo.AnoLetivo1);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaPeriodo = _periodoService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaPeriodo, typeof(IEnumerable<Periodo>));
            Assert.IsNotNull(listaPeriodo);
            Assert.AreEqual(3, listaPeriodo.Count());
            Assert.AreEqual(1, listaPeriodo.First().Id);
        }
    }
}