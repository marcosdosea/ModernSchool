using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernSchoolWEB.Mappers;
using ModernSchoolWEB.Models;
using ModernSchoolWEB.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernSchoolWEBTest.Controllers.Tests
{
    [TestClass()]
    public class ComunicacaoControllerTests
    {
        private static ComunicacaoController controller;

        [TestInitialize]
        public void Initialize()
        {
            var mockService = new Mock<IComunicacaoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new ComunicacaoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestComunicacaos());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetComunicacaos());
            mockService.Setup(service => service.Edit(It.IsAny<Comunicacao>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Comunicacao>()))
                .Verifiable();
            controller = new ComunicacaoController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<ComunicacaoViewModel>));

            List<ComunicacaoViewModel> lista = (List<ComunicacaoViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ComunicacaoViewModel));
            ComunicacaoViewModel comunicacaoViewModel = (ComunicacaoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, comunicacaoViewModel.Id);
            Assert.AreEqual(1, comunicacaoViewModel.IdTurma);
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
            var result = controller.Create(GetNewComunicacao());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        public void CreateTest_Post_InValid()
        {
            // Arrange
            controller.ModelState.AddModelError("Nome", "Campo requerido");

            // Act
            var result = controller.Create(GetNewComunicacao());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private ComunicacaoViewModel GetNewComunicacao()
        {
            return new ComunicacaoViewModel
            {
                Id = 1,
                EnviarAlunos = 30,
                EnviarResponsaveis = 0,
                Mensagem = "Recuperação amanhã",
                IdTurma = 1,
                IdComponente = 2
            };
        }

        [TestMethod()]
        public void EditTest_Get()
        {
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ComunicacaoViewModel));
            ComunicacaoViewModel comunicacaoViewModel = (ComunicacaoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, comunicacaoViewModel.Id);
            Assert.AreEqual(1, comunicacaoViewModel.IdTurma);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(GetTargetComunicacaoViewModel().Id, GetTargetComunicacaoViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ComunicacaoViewModel));
            ComunicacaoViewModel comunicacaoViewModel = (ComunicacaoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, comunicacaoViewModel.Id);
            Assert.AreEqual(1, comunicacaoViewModel.IdTurma);
        }

        [TestMethod()]
        public void DeleteTest_Post()
        {
            // Act
            var result = controller.Delete(GetTargetComunicacaoViewModel().Id, GetTargetComunicacaoViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private Comunicacao GetTargetComunicacaos()
        {
            return new Comunicacao
            {
                Id = 1,
                EnviarAlunos = 30,
                EnviarResponsaveis = 0,
                Mensagem = "Recuperação amanhã",
                IdTurma = 1,
                IdComponente = 2
            };
        }

        private IEnumerable<Comunicacao> GetTestComunicacaos()
        {
            return new List<Comunicacao>
            {
                 new Comunicacao
                {
                    Id = 1,
                    EnviarAlunos = 30,
                    EnviarResponsaveis = 0,
                    Mensagem = "Recuperação amanhã",
                    IdTurma = 1,
                    IdComponente = 2
                },
                new Comunicacao
                {
                    Id = 2,
                    EnviarAlunos = 0,
                    EnviarResponsaveis = 20,
                    Mensagem = "Reuniao de pais",
                    IdTurma = 1,
                    IdComponente = 2
                },
                new Comunicacao
                {
                    Id = 3,
                    EnviarAlunos = 20,
                    EnviarResponsaveis = 20,
                    Mensagem = "Festeijo junino acontecerá na escolha contamos com pais e alunos presentes.",
                    IdTurma = 1,
                    IdComponente = 2
                }
            };
        }

        private ComunicacaoViewModel GetTargetComunicacaoViewModel()
        {
            return new ComunicacaoViewModel
            {
                Id = 2,
                EnviarAlunos = 0,
                EnviarResponsaveis = 20,
                Mensagem = "Reuniao de pais",
                IdTurma = 1,
                IdComponente = 2
            };
        }
    }
}
