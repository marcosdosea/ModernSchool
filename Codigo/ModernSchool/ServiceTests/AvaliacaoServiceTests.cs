using Core.Service;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Service;

namespace ServiceTests
{
    [TestClass()]
    public class AvaliacaoServiceTests
    {
        private ModernSchoolContext _context;
        private IAvaliacaoService _avaliacaoService;
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
            var avaliacoes = new List<Avaliacao>
                {
                   new Avaliacao { Id = 1, DataEntrega = DateTime.Parse("2022-10-01"), HorarioEntrega = DateTime.Parse("00:00:00"), TipoDeAtividade = "Prova", Peso = 3, Avaliativo = true, IdTurma = 1, IdComponente = 1, IdPeriodo = 1},
                   new Avaliacao { Id = 2, DataEntrega = DateTime.Parse("2022-11-20"), HorarioEntrega = DateTime.Parse("23:59:00"), TipoDeAtividade = "Projeto", Peso = 3, Avaliativo = false, IdTurma = 1, IdComponente = 1, IdPeriodo = 1},
                   new Avaliacao { Id = 3, DataEntrega = DateTime.Parse("2022-12-30"), HorarioEntrega = DateTime.Parse("00:00:00"), TipoDeAtividade = "Projeto", Peso = 3, Avaliativo = false, IdTurma = 1, IdComponente = 1, IdPeriodo = 1},

                };

            _context.AddRange(avaliacoes);
            _context.SaveChanges();

            _avaliacaoService = new AvaliacaoService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _avaliacaoService.Create(new Avaliacao() { Id = 1, DataEntrega = DateTime.Parse("01/11/2022"), HorarioEntrega = DateTime.Parse("23:59:00"), IdTurma = 1 });
            // Assert
            Assert.AreEqual(1, _avaliacaoService.GetAll().Count());
            var avaliacao = _avaliacaoService.Get(1);
            Assert.AreEqual(1, avaliacao.Avaliativo);
            Assert.AreEqual(DateTime.Parse("11/11/2025"), avaliacao.DataEntrega);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            _avaliacaoService.Delete(1);
            // Assert
            Assert.AreEqual(2, _avaliacaoService.GetAll().Count());
            var anoletivo = _avaliacaoService.Get(1);
            Assert.AreEqual(null, anoletivo);
        }

        [TestMethod()]
        public void EditTest()
        {
            var avaliacao = _avaliacaoService.Get(1);
            avaliacao.Id = 1;
            avaliacao.DataEntrega = DateTime.Parse("2022-11-21");
            _avaliacaoService.Edit(avaliacao);
            //Assert
            avaliacao = _avaliacaoService.Get(1);
            Assert.IsNotNull(avaliacao);
            Assert.AreEqual(1, avaliacao.Avaliativo);
            Assert.AreEqual(DateTime.Parse("2022-11-30"), avaliacao.DataEntrega);
        }

        [TestMethod()]
        public void GetTest()
        {
            var avaliacao = _avaliacaoService.Get(2022);
            Assert.IsNotNull(avaliacao);
            Assert.AreEqual(1, avaliacao.Avaliativo);
            Assert.AreEqual(DateTime.Parse("2022-11-10"), avaliacao.DataEntrega);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaAvaliacao = _avaliacaoService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaAvaliacao, typeof(IEnumerable<Anoletivo>));
            Assert.IsNotNull(listaAvaliacao);
            Assert.AreEqual(1, listaAvaliacao.Count());
            Assert.AreEqual(1, listaAvaliacao.First().Avaliativo);
        }
    }
}
