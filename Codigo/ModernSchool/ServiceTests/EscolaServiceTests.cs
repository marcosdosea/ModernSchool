﻿using Core.Service;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Service.Tests
{
    [TestClass()]
    public class EscolaServiceTests
    {

        private ModernSchoolContext _context;
        private IEscolaService _escolaService;
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
            var escolas = new List<Escola>
                {
                    new Escola { Id = 1, Nome = "colegio estadual prof nestor carvalho",  Cnpj = "34047391000111",
                 Bairro = "centro",
                 Rua = "Elizio Araujo",
                 Numero = 132,
                 IdGoverno =1},

                    new Escola { Id = 2, Nome = "colegio estadual murilo braga",  Cnpj = "78308468000135",
                 Bairro = "Marianga",
                 Rua = "Gumercindo de oliveira",
                 Numero = 51,
                 IdGoverno = 1},
                    new Escola { Id = 3, Nome = "colegio estadual benedito figueiredo",
                 Cnpj = "33286151000107",
                 Bairro = "Centro",
                 Rua = "Percilio Andrade",
                 Numero = 1011,
                 IdGoverno = 2},
                };

            _context.AddRange(escolas);
            _context.SaveChanges();

            _escolaService = new EscolaService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            _escolaService.Create(new Escola { Id = 4, Nome = "colegio estadual cesar leite", Numero = 130, Cnpj = "47506202000173" });
            // Assert
            Assert.AreEqual(4, _escolaService.GetAll().Count());
            var escola = _escolaService.Get(4);
            Assert.AreEqual(4, escola.Id);
            Assert.AreEqual("colegio estadual cesar leite", escola.Nome);
            Assert.AreEqual("47506202000173", escola.Cnpj);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            _escolaService.Delete(2);
            // Assert
            Assert.AreEqual(2, _escolaService.GetAll().Count());
            var escola = _escolaService.Get(2);
            Assert.AreEqual(null, escola);
        }

        [TestMethod()]
        public void EditTest()
        {
            var escola = _escolaService.Get(1);
            escola.Id = 1;
            escola.Nome = "colegio estadual prof nestor carvalho";
            _escolaService.Edit(escola);
            //Assert
            escola = _escolaService.Get(1);
            Assert.IsNotNull(escola);
            Assert.AreEqual(1, escola.Id);
            Assert.AreEqual("colegio estadual prof nestor carvalho", escola.Nome);
            Assert.AreEqual("34047391000111", escola.Cnpj);
        }

        [TestMethod()]
        public void GetTest()
        {
            var escola = _escolaService.Get(2);
            Assert.IsNotNull(escola);
            Assert.AreEqual(2, escola.Id);
            Assert.AreEqual("colegio estadual murilo braga", escola.Nome);
            Assert.AreEqual("78308468000135", escola.Cnpj);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaEscolas = _escolaService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaEscolas, typeof(IEnumerable<Escola>));
            Assert.IsNotNull(listaEscolas);
            Assert.AreEqual(3, listaEscolas.Count());
            Assert.AreEqual(1, listaEscolas.First().Id);
        }
    }
}