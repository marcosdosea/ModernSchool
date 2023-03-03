using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernSchoolWEB.Controllers;
using ModernSchoolWEB.Mappers;
using ModernSchoolWEB.Models;
using Moq;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ModernSchoolWEBTest.Controllers.Tests
{
    [TestClass()]
    public class EscolaControllerTests
    {
        private static EscolaController controller;

        [TestInitialize]
        public void Initialize()
        {
            var mockService = new Mock<IEscolaService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new EscolaProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestEscolas());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetEscola());
            mockService.Setup(service => service.Edit(It.IsAny<Escola>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Escola>()))
                .Verifiable();
            controller = new EscolaController(mockService.Object, mapper);
        }

        private Escola GetTargetEscola()
        {
            return new Escola
            {
                Id = 1,
                Nome = "colegio estadual prof nestor carvalho",
                Cnpj = "34047391000111",
                Bairro = "centro",
                Rua = "Elizio Araujo",
                Numero = 132,
                IdGoverno =1
            };
        }

        private IEnumerable<Escola> GetTestEscolas()
        {
            return new List<Escola>
            {
             new Escola
             {
                 Id = 1,
                 Nome = "colegio estadual prof nestor carvalho",
                 Cnpj = "34047391000111",
                 Bairro = "centro",
                 Rua = "Elizio Araujo",
                 Numero = 132,
                 IdGoverno =1

             },
             new Escola
             {
                 Id = 2,
                 Nome = "colegio estadual murilo braga",
                 Cnpj = "78308468000135",
                 Bairro = "Marianga",
                 Rua = "Gumercindo de oliveira",
                 Numero = 51,
                 IdGoverno = 1
             },
             new Escola
             {
                 Id = 3,
                 Nome = "colegio estadual benedito figueiredo",
                 Cnpj = "33286151000107",
                 Bairro = "Centro",
                 Rua = "Percilio Andrade",
                 Numero = 1011,
                 IdGoverno = 2
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<EscolaViewModel>));

            List<EscolaViewModel> lista = (List<EscolaViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(EscolaViewModel));
            EscolaViewModel escolaViewModel = (EscolaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, escolaViewModel.Id);
            Assert.AreEqual("colegio estadual prof nestor carvalho", escolaViewModel.Nome);
            Assert.AreEqual("34047391000111", escolaViewModel.Cnpj);
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
            var result = controller.Create(GetNewEscola());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
        [TestMethod()]
        public void CreateTest_Post_InValid()
        {
            // Arrange
            controller.ModelState.AddModelError("Nome", "Campo requerido");

            // Act
            var result = controller.Create(GetNewEscola());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private EscolaViewModel GetNewEscola()
        {
            return new EscolaViewModel
            {
                Id = 1,
                Nome = "colegio estadual prof nestor carvalho",
                Cnpj = "34047391000111",
                Bairro = "centro",
                Rua = "Elizio Araujo",
                Numero = 132,
                IdGoverno = 1
            };
        }

        [TestMethod()]
        public void EditTest_Get()
        {
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(EscolaViewModel));
            EscolaViewModel escolaViewModel = (EscolaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, escolaViewModel.Id);
            Assert.AreEqual("colegio estadual prof nestor carvalho", escolaViewModel.Nome);
            Assert.AreEqual("34047391000111", escolaViewModel.Cnpj);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            var result = controller.Edit(GetTargetEscolaViewModel().Id, GetTargetEscolaViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private EscolaViewModel GetTargetEscolaViewModel()
        {
            return new EscolaViewModel
            {
                Id = 2,
                Nome = "colegio estadual murilo braga",
                Cnpj = "78308468000135",
                Bairro = "Marianga",
                Rua = "Gumercindo de oliveira",
                Numero = 51,
                IdGoverno = 1
            };
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(EscolaViewModel));
            EscolaViewModel escolaViewModel = (EscolaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, escolaViewModel.Id);
            Assert.AreEqual("colegio estadual prof nestor carvalho", escolaViewModel.Nome);
            Assert.AreEqual("34047391000111", escolaViewModel.Cnpj);
        }

        [TestMethod()]
        public void DeleteTest_Post()
        {
            var result = controller.Delete(GetTargetEscolaViewModel().Id, GetTargetEscolaViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
    }
}