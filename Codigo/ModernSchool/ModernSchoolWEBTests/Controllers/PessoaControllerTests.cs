using AutoMapper;
using Core.Service;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernSchoolWEB.Controllers;
using ModernSchoolWEB.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernSchoolWEB.Mappers;

namespace ModernSchoolWEBTests.Controllers.Tests
{
    [TestClass()]
    public class PessoaControllerTests
    {
        private static PessoaController controller;

        [TestInitialize]
        public void Initialize()
        {
            var mockService = new Mock<IPessoaService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new PessoaProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestPessoas());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetPessoa());
            mockService.Setup(service => service.Edit(It.IsAny<Pessoa>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Pessoa>()))
                .Verifiable();
            controller = new PessoaController(mockService.Object, mapper);
        }

        private Pessoa GetTargetPessoa()
        {
            return new Pessoa
            {
                Id = 1,
                Nome = "Moises Junio Fagundes Dos Santos",
                Cpf = "86413068035",
                Idade = 15,
                Rua = "Gumercindo de oliveira",
                Bairro = "Centro",
                Numero = 221,
                DataNascimento = DateTime.Parse("2008/02/02")
            };
        }

        private IEnumerable<Pessoa> GetTestPessoas()
        {
            return new List<Pessoa>
            {
                new Pessoa
                {
                    Id = 1,
                    Nome = "Moises Junio Fagundes Dos Santos",
                    Cpf = "86413068035",
                    Idade = 15,
                    Rua = "Gumercindo de oliveira",
                    Bairro = "Centro",
                    Numero = 221,
                    DataNascimento = DateTime.Parse("2008/02/02")
                },
                new Pessoa
                {
                    Id = 2,
                    Nome = "Mateus da cruz souza",
                    Cpf = "74432021055",
                    Idade = 17,
                    Rua = "Percilio andrade",
                    Bairro = "Centro",
                    Numero = 21,
                    DataNascimento = DateTime.Parse("2005/05/12")
                },
                new Pessoa
                {
                    Id = 3,
                    Nome = "Reinan de Jesus Santoa",
                    Cpf = "65627407034",
                    Idade = 15,
                    DataNascimento = DateTime.Parse("2008/01/23")
                }
            };
        }


        [TestMethod()]
        public void IndexTest()
        {
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<PessoaViewModel>));

            List<PessoaViewModel> lista = (List<PessoaViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaViewModel));
            PessoaViewModel pessoaViewModel = (PessoaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, pessoaViewModel.Id);
            Assert.AreEqual("86413068035", pessoaViewModel.Cpf);
            Assert.AreEqual("Gumercindo de oliveira", pessoaViewModel.Rua);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            var result = controller.Create();
            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void CreateTest_Post_Valid()
        {
            // Act
            var result = controller.Create(GetNewPessoa());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private PessoaViewModel GetNewPessoa()
        {
            return new PessoaViewModel
            {
                Id = 1,
                Nome = "Moises Junio Fagundes Dos Santos",
                Cpf = "86413068035",
                Idade = 15,
                Rua = "Gumercindo de oliveira",
                Bairro = "Centro",
                Numero = 221,
                DataNascimento = DateTime.Parse("2008/02/02")
            };
        }

        public void CreateTest_Post_InValid()
        {
            // Arrange
            controller.ModelState.AddModelError("Nome", "Campo requerido");

            // Act
            var result = controller.Create(GetNewPessoa());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void EditTest_Get()
        {
            var result = controller.Edit(2);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AnoLetivoViewModel));
            PessoaViewModel pessoaViewModel = (PessoaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(2, pessoaViewModel.Id);
            Assert.AreEqual("74432021055", pessoaViewModel.Cpf);
            Assert.AreEqual("Mateus da cruz souza", pessoaViewModel.Nome);

        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(GetTargetPessoaViewModel().Id, GetTargetPessoaViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private PessoaViewModel GetTargetPessoaViewModel()
        {
            return new PessoaViewModel
            {
                Id = 2,
                Nome = "Mateus da cruz souza",
                Cpf = "74432021055",
                Idade = 17,
                Rua = "Percilio andrade",
                Bairro = "Centro",
                Numero = 21,
                DataNascimento = DateTime.Parse("2005/05/12")
            };
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            var result = controller.Delete(3);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AnoLetivoViewModel));
            PessoaViewModel pessoaViewModel = (PessoaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, pessoaViewModel.Id);
            Assert.AreEqual("Reinan de Jesus Santoa", pessoaViewModel.Nome);
            Assert.AreEqual("65627407034", pessoaViewModel.Cpf);
        }

        [TestMethod()]
        public void DeleteTest_Post()
        {
            // Act
            var result = controller.Delete(GetTargetPessoaViewModel().Id, GetTargetPessoaViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }


    }
}


