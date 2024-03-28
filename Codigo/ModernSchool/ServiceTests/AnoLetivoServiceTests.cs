using Core;
using Core.Service;
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
    public class AnoLetivoServiceTests
    {
        private ModernSchoolContext _context;
        private IAnoLetivoService _anoLetivoService;
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
            var anoletivos = new List<Anoletivo>
                {
                    new Anoletivo { AnoLetivo = 2022, DataInicio = DateTime.Parse("2022-01-01"), DataFim = DateTime.Parse("2022-11-11"), IdEscola = 1},
                    new Anoletivo { AnoLetivo = 2023, DataInicio = DateTime.Parse("2023-01-01"), DataFim = DateTime.Parse("2023-11-11"), IdEscola = 1},
                    new Anoletivo { AnoLetivo = 2024, DataInicio = DateTime.Parse("2024-11-11"), DataFim = DateTime.Parse("2024-11-11"), IdEscola = 1},
                };

            _context.AddRange(anoletivos);
            _context.SaveChanges();

            _anoLetivoService = new AnoLetivoService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _anoLetivoService.Create(new Anoletivo() { AnoLetivo = 2025, DataInicio = DateTime.Parse("01/01/2025"), DataFim = DateTime.Parse("11/11/2025"), IdEscola = 1 });
            // Assert
            Assert.AreEqual(4, _anoLetivoService.GetAll().Count());
            var anoletivo = _anoLetivoService.Get(2025);
            Assert.AreEqual(2025, anoletivo.AnoLetivo);
            Assert.AreEqual(DateTime.Parse("11/11/2025"), anoletivo.DataFim);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            _anoLetivoService.Delete(2023);
            // Assert
            Assert.AreEqual(2, _anoLetivoService.GetAll().Count());
            var anoletivo = _anoLetivoService.Get(2023);
            Assert.AreEqual(null, anoletivo);
        }

        [TestMethod()]
        public void EditTest()
        {
            var anoletivo = _anoLetivoService.Get(2022);
            anoletivo.AnoLetivo = 2022;
            anoletivo.DataInicio = DateTime.Parse("2022-01-01");
            _anoLetivoService.Edit(anoletivo);
            //Assert
            anoletivo = _anoLetivoService.Get(2022);
            Assert.IsNotNull(anoletivo);
            Assert.AreEqual(2022, anoletivo.AnoLetivo);
            Assert.AreEqual(DateTime.Parse("2022-01-01"), anoletivo.DataInicio);
        }

        [TestMethod()]
        public void GetTest()
        {
            var anoletivo = _anoLetivoService.Get(2022);
            Assert.IsNotNull(anoletivo);
            Assert.AreEqual(2022, anoletivo.AnoLetivo);
            Assert.AreEqual(DateTime.Parse("2022-01-01"), anoletivo.DataInicio);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaAnoLetivo = _anoLetivoService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaAnoLetivo, typeof(IEnumerable<Anoletivo>));
            Assert.IsNotNull(listaAnoLetivo);
            Assert.AreEqual(3, listaAnoLetivo.Count());
            Assert.AreEqual(2022, listaAnoLetivo.First().AnoLetivo);
        }
    }
}