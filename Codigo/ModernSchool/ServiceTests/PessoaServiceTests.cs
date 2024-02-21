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
    public class PessoaServiceTests
    {
        private ModernSchoolContext _context;
        private IPessoaService _pessoaService;

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
            var pessoas = new List<Pessoa>
                {
                    new Pessoa {  Id = 1,
                    Nome = "Moises Junio Fagundes Dos Santos",
                    Cpf = "86413068035",
                    //Idade = 15,
                    Rua = "Gumercindo de oliveira",
                    Bairro = "Centro",
                    Numero = 221,
                    DataNascimento = DateTime.Parse("2008/02/02")},
                    new Pessoa {  Id = 2,
                    Nome = "Mateus da cruz souza",
                    Cpf = "74432021055",
                    //Idade = 17,
                    Rua = "Percilio andrade",
                    Bairro = "Centro",
                    Numero = 21,
                    DataNascimento = DateTime.Parse("2005/05/12")},
                    new Pessoa {  Id = 3,
                    Nome = "Reinan de Jesus Santoa",
                    Cpf = "65627407034",
                    //Idade = 15,
                    DataNascimento = DateTime.Parse("2008/01/23")},
                };

            _context.AddRange(pessoas);
            _context.SaveChanges();

            _pessoaService = new PessoaService(_context);
        }
        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _pessoaService.Create(new Pessoa()
            {
                Id = 4,
                Nome = "Marlene Carvalho Santos",
                Cpf = "20412100010",
                //
                //Idade = 17,
                DataNascimento = DateTime.Parse("2005/03/25")
            });
            // Assert
            Assert.AreEqual(4, _pessoaService.GetAll().Count());
            var pessoa = _pessoaService.Get(4);
            Assert.AreEqual(4, pessoa.Id);
            Assert.AreEqual("20412100010", pessoa.Cpf);
            Assert.AreEqual("Marlene Carvalho Santos", pessoa.Nome);
        }
        [TestMethod()]
        public void DeleteTest()
        {
            _pessoaService.Delete(3);
            // Assert
            Assert.AreEqual(2, _pessoaService.GetAll().Count());
            var pessoa= _pessoaService.Get(3);
            Assert.AreEqual(null, pessoa);
        }

        [TestMethod()]
        public void EditTest()
        {
            var pessoa = _pessoaService.Get(1);
            pessoa.Rua = "Francisco Bragança";
            pessoa.Bairro = "Sao Cristovao";
            _pessoaService.Edit(pessoa);
            //Assert
            pessoa = _pessoaService.Get(1);
            Assert.IsNotNull(pessoa);
            Assert.AreEqual(1, pessoa.Id);
            Assert.AreEqual("86413068035", pessoa.Cpf);
            Assert.AreEqual("Francisco Bragança", pessoa.Rua);
        }

        [TestMethod()]
        public void GetTest()
        {
            var pessoa = _pessoaService.Get(1);
            Assert.IsNotNull(pessoa);
            Assert.AreEqual(1, pessoa.Id);
            Assert.AreEqual("86413068035", pessoa.Cpf);
            Assert.AreEqual("Gumercindo de oliveira", pessoa.Rua);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaPessoas = _pessoaService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaPessoas, typeof(IEnumerable<Pessoa>));
            Assert.IsNotNull(listaPessoas);
            Assert.AreEqual(3, listaPessoas.Count());
            Assert.AreEqual("86413068035", listaPessoas.First().Cpf);
        }

    }
}
