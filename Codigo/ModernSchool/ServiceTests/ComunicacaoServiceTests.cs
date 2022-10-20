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
    public class ComunicacaoServiceTests
    {
        private ModernSchoolContext _context;
        private IComunicacaoService _comunicacaoService;
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
            var comunicacaos = new List<Comunicacao>
                {
                    new Comunicacao { Id = 1, EnviarResponsaveis = 0, EnviarAlunos = 30, Mensagem = "Recuperação amanhã", IdTurma = 1, IdComponente = 2},
                    new Comunicacao { Id = 2, EnviarResponsaveis = 30, EnviarAlunos = 30, Mensagem = "Festeijo junino será adiado para dia 28", IdTurma = 1, IdComponente = 2},
                    new Comunicacao { Id = 3, EnviarResponsaveis = 1, EnviarAlunos = 0, Mensagem = "Seu filho tomou uma adivertência", IdTurma = 1, IdComponente = 2},
                };

            _context.AddRange(comunicacaos);
            _context.SaveChanges();

            _comunicacaoService = new ComunicacaoService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _comunicacaoService.Create(new Comunicacao() { Id = 4, EnviarAlunos = 10, EnviarResponsaveis = 0, Mensagem = "Recuperação semestral amanhã", IdTurma = 2, IdComponente = 3 });
            // Assert
            Assert.AreEqual(4, _comunicacaoService.GetAll().Count());
            var comunicacao = _comunicacaoService.Get(4);
            Assert.AreEqual(4, comunicacao.Id);
            Assert.AreEqual(2, comunicacao.IdTurma);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            _comunicacaoService.Delete(3);
            // Assert
            Assert.AreEqual(2, _comunicacaoService.GetAll().Count());
            var comunicacao = _comunicacaoService.Get(3);
            Assert.AreEqual(null, comunicacao);
        }

        [TestMethod()]
        public void EditTest()
        {
            var comunicacao = _comunicacaoService.Get(1);
            comunicacao.Id = 1;
            comunicacao.IdComponente = 2;
            _comunicacaoService.Edit(comunicacao);
            //Assert
            comunicacao = _comunicacaoService.Get(1);
            Assert.IsNotNull(comunicacao);
            Assert.AreEqual(1, comunicacao.Id);
            Assert.AreEqual(2, comunicacao.IdComponente);
        }

        [TestMethod()]
        public void GetTest()
        {
            var comunicacao = _comunicacaoService.Get(2);
            Assert.IsNotNull(comunicacao);
            Assert.AreEqual(2, comunicacao.Id);
            Assert.AreEqual(2, comunicacao.IdComponente);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaComunicacao = _comunicacaoService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaComunicacao, typeof(IEnumerable<Comunicacao>));
            Assert.IsNotNull(listaComunicacao);
            Assert.AreEqual(3, listaComunicacao.Count());
            Assert.AreEqual(1, listaComunicacao.First().Id);
        }
    }
}