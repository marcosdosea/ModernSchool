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
    public class CargoServiceTests
    {
        private ModernSchoolContext _context;
        private ICargoService _cargoService;
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
            var cargos = new List<Cargo>
                {
                    new Cargo { IdCargo = 1, Descricao = "Faxineiro"},
                    new Cargo { IdCargo = 2, Descricao = "Cozinheiro"},
                    new Cargo { IdCargo = 3, Descricao = "Professor"},
                };

            _context.AddRange(cargos);
            _context.SaveChanges();

            _cargoService = new CargoService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _cargoService.Create(new Cargo() { IdCargo = 4, Descricao = "Coordenador" });
            // Assert
            Assert.AreEqual(4, _cargoService.GetAll().Count());
            var cargo = _cargoService.Get(4);
            Assert.AreEqual(4, cargo.IdCargo);
            Assert.AreEqual("Coordenador", cargo.Descricao);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            _cargoService.Delete(3);
            // Assert
            Assert.AreEqual(2, _cargoService.GetAll().Count());
            var cargo = _cargoService.Get(3);
            Assert.AreEqual(null, cargo);
        }

        [TestMethod()]
        public void EditTest()
        {
            var cargo = _cargoService.Get(1);
            cargo.IdCargo = 1;
            cargo.Descricao = "Faxineiro";
            _cargoService.Edit(cargo);
            //Assert
            cargo = _cargoService.Get(1);
            Assert.IsNotNull(cargo);
            Assert.AreEqual(1, cargo.IdCargo);
            Assert.AreEqual("Faxineiro", cargo.Descricao);
        }

        [TestMethod()]
        public void GetTest()
        {
            var cargo = _cargoService.Get(2);
            Assert.IsNotNull(cargo);
            Assert.AreEqual(2, cargo.IdCargo);
            Assert.AreEqual("Cozinheiro", cargo.Descricao);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaCargo = _cargoService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaCargo, typeof(IEnumerable<Cargo>));
            Assert.IsNotNull(listaCargo);
            Assert.AreEqual(3, listaCargo.Count());
            Assert.AreEqual(1, listaCargo.First().IdCargo);
        }
    }
}