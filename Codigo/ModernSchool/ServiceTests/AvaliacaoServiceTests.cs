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

namespace Service.Tests
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
                   new Avaliacao { Id = 1, DataEntrega = new DateTime(2022,01,01), HorarioEntrega = new DateTime(2022,01,01) ,
                       TipoDeAtividade = "Prova", Peso = 7, Avaliativo = true, IdTurma = 1, IdComponente = 1, IdPeriodo = 1},
                   new Avaliacao { Id = 2, DataEntrega = new DateTime(2022,02,01), HorarioEntrega = new DateTime(2022,02,01),
                       TipoDeAtividade = "Projeto", Peso = 8, Avaliativo = false, IdTurma = 1, IdComponente = 1, IdPeriodo = 1},
                   new Avaliacao { Id = 3, DataEntrega = new DateTime(2022,03,01), HorarioEntrega = new DateTime(2022,03,01),
                       TipoDeAtividade = "Projeto", Peso = 5, Avaliativo = false, IdTurma = 1, IdComponente = 1, IdPeriodo = 1},

                };

            _context.AddRange(avaliacoes);
            _context.SaveChanges();

            _avaliacaoService = new AvaliacaoService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _avaliacaoService.Create(new Avaliacao()
            {
                Id = 4,
                DataEntrega = new DateTime(2022, 01, 04),
                HorarioEntrega = new DateTime(2022, 01, 05),
                IdTurma = 1,
                Avaliativo = true,
                IdComponente = 1,
                IdPeriodo = 1,
                Peso = 7,
                TipoDeAtividade = "PROVA"

            });
            short peso = 7;
            // Assert
            Assert.AreEqual(4, _avaliacaoService.GetAll().Count());
            var avaliacao = _avaliacaoService.Get(4);
            Assert.AreEqual(new DateTime(2022, 01, 04), avaliacao.DataEntrega);
            Assert.AreEqual(4, avaliacao.Id);
            Assert.AreEqual(new DateTime(2022, 01, 05), avaliacao.HorarioEntrega);
            Assert.AreEqual(1, avaliacao.IdTurma);
            Assert.AreEqual(1, avaliacao.IdComponente);
            Assert.AreEqual(1, avaliacao.IdPeriodo);
            Assert.AreEqual("PROVA", avaliacao.TipoDeAtividade);
            Assert.AreEqual(true, avaliacao.Avaliativo);
            Assert.AreEqual(peso, avaliacao.Peso);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            _avaliacaoService.Delete(2);
            // Assert
            Assert.AreEqual(2, _avaliacaoService.GetAll().Count());
            var avaliacao = (_avaliacaoService.Get(2));
            Assert.IsNull(avaliacao);

        }

        [TestMethod()]
        public void EditTest()
        {
            short peso = 10;
            var avaliacao = _avaliacaoService.Get(3);
            avaliacao.DataEntrega = new DateTime(2022, 04, 01);
            avaliacao.Avaliativo = true;
            avaliacao.HorarioEntrega = new DateTime(2022, 04, 01);
            avaliacao.Peso = peso;
            avaliacao.TipoDeAtividade = "PROVA";

            avaliacao = _avaliacaoService.Get(3);

            //Assert
            Assert.IsNotNull(avaliacao);
            Assert.AreEqual(new DateTime(2022, 04, 01), avaliacao.DataEntrega);
            Assert.AreEqual(new DateTime(2022, 04, 01), avaliacao.HorarioEntrega);
            Assert.AreEqual(true, avaliacao.Avaliativo);
            Assert.AreEqual(peso, avaliacao.Peso);
            Assert.AreEqual("PROVA", avaliacao.TipoDeAtividade);


        }

        [TestMethod()]
        public void GetTest()
        {
            short peso = 7;
            var avaliacao = _avaliacaoService.Get(1);
            Assert.IsNotNull(avaliacao);
            Assert.AreEqual(new DateTime(2022, 01, 01), avaliacao.DataEntrega);
            Assert.AreEqual(new DateTime(2022, 01, 01), avaliacao.HorarioEntrega);
            Assert.AreEqual("Prova", avaliacao.TipoDeAtividade);
            Assert.AreEqual(peso, avaliacao.Peso);
            Assert.AreEqual(1, avaliacao.IdTurma);
            Assert.AreEqual(1, avaliacao.IdComponente);
            Assert.AreEqual(1, avaliacao.IdPeriodo);
            Assert.AreEqual(true, avaliacao.Avaliativo);
            Assert.AreEqual(1, avaliacao.Id);

        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaAvaliacao = _avaliacaoService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaAvaliacao, typeof(IEnumerable<Avaliacao>));
            Assert.IsNotNull(listaAvaliacao);
            Assert.AreEqual(3, listaAvaliacao.Count());
            Assert.AreEqual(1, listaAvaliacao.First().Id);
        }
    }
}
