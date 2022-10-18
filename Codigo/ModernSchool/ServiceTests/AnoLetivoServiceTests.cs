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
        [TestMethod()]
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
                    new Anoletivo { AnoLetivo = 2022, DataInicio = DateTime.Parse("01/01/2022"), DataFim = DateTime.Parse("11/11/2022"), IdEscola = 1},
                    new Anoletivo { AnoLetivo = 2023, DataInicio = DateTime.Parse("01/01/2023"), DataFim = DateTime.Parse("11/11/2023"), IdEscola = 1},
                    new Anoletivo { AnoLetivo = 2024, DataInicio = DateTime.Parse("01/01/2024"), DataFim = DateTime.Parse("11/11/2024"), IdEscola = 1},
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
            var anoletivo = _anoLetivoService.Get(4);
            Assert.AreEqual(2025, anoletivo.AnoLetivo);
            Assert.AreEqual(DateTime.Parse("11/11/2025"), anoletivo.DataFim);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            _anoLetivoService.Delete(2);
            // Assert
            Assert.AreEqual(2, _anoLetivoService.GetAll().Count());
            var anoletivo = _anoLetivoService.Get(2);
            Assert.AreEqual(null, anoletivo);
        }

        [TestMethod()]
        public void EditTest()
        {
            var anoletivo = _anoLetivoService.Get(3);
            anoletivo.AnoLetivo = 2022;
            anoletivo.DataInicio = DateTime.Parse("01/01/2022");
            _anoLetivoService.Edit(anoletivo);
            //Assert
            anoletivo = _anoLetivoService.Get(3);
            Assert.IsNotNull(anoletivo);
            Assert.AreEqual(2022, anoletivo.AnoLetivo);
            Assert.AreEqual(DateTime.Parse("01/01/2022"), anoletivo.DataInicio);
        }

        [TestMethod()]
        public void GetTest()
        {
            var anoletivo = _anoLetivoService.Get(1);
            Assert.IsNotNull(anoletivo);
            Assert.AreEqual(2022, anoletivo.AnoLetivo);
            Assert.AreEqual(DateTime.Parse("01/01/2022"), anoletivo.DataInicio);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaAutor = _anoLetivoService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaAutor, typeof(IEnumerable<Anoletivo>));
            Assert.IsNotNull(listaAutor);
            Assert.AreEqual(3, listaAutor.Count());
            Assert.AreEqual(1, listaAutor.First().AnoLetivo);
            Assert.AreEqual(2022, listaAutor.First().AnoLetivo);
        }
    }
}