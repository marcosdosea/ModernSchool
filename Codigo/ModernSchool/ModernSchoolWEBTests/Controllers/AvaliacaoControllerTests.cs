using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernSchoolWEB.Controllers;
using ModernSchoolWEB.Mappers;
using ModernSchoolWEB.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernSchoolWEBTests.Controllers
{
    [TestClass()]
    public class AvaliacaoControllerTests
    {
        private static AvaliacaoController controller;

        [TestInitialize]
        public void Initialize()
        {
            var mockService = new Mock<IAvaliacaoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new AvaliacaoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestAvaliacao());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetAvaliacao());
            mockService.Setup(service => service.Edit(It.IsAny<Avaliacao>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Avaliacao>()))
                .Verifiable();
            //controller = new AvaliacaoController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<AvaliacaoViewModel>));

            List<AvaliacaoViewModel> lista = (List<AvaliacaoViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AvaliacaoViewModel));
            AvaliacaoViewModel AvaliacaoViewModel = (AvaliacaoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, AvaliacaoViewModel.Id);
            Assert.AreEqual("20220608", AvaliacaoViewModel.DataEntrega);
            Assert.AreEqual("20220610", AvaliacaoViewModel.HorarioEntrega);
            Assert.AreEqual("Projeto", AvaliacaoViewModel.TipoDeAtividade);
            Assert.AreEqual(3, AvaliacaoViewModel.Peso);
            Assert.AreEqual(1, AvaliacaoViewModel.Avaliativo);
            Assert.AreEqual(1, AvaliacaoViewModel.IdTurma);
            Assert.AreEqual(1, AvaliacaoViewModel.IdComponente);
            Assert.AreEqual(1, AvaliacaoViewModel.IdPeriodo);
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
            var result = controller.Create(GetNewAvaliacao());

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
            var result = controller.Create(GetNewAvaliacao());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
         private AvaliacaoViewModel GetNewAvaliacao()
        {
            return new AvaliacaoViewModel
            {
                Id= 1,
                DataEntrega = DateTime.Parse("2022-01-01"),
                HorarioEntrega = DateTime.Parse("20:00:00:00"),
                TipoDeAtividade = "Projeto",
                Peso = 3,
                Avaliativo = 0,
                IdTurma = 1,
                IdComponente = 1,
                IdPeriodo = 1
            };
        }

        [TestMethod()]
        public void EditTest_Get()
        {
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AvaliacaoViewModel));
            AvaliacaoViewModel avaliacaoViewModel = (AvaliacaoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(20220203, avaliacaoViewModel.DataEntrega);
            Assert.AreEqual(202202, avaliacaoViewModel.HorarioEntrega);
            Assert.AreEqual("Projeto", avaliacaoViewModel.TipoDeAtividade);
            Assert.AreEqual(0, avaliacaoViewModel.Avaliativo); //verificar, tipo de dados Bool
            Assert.AreEqual(1, avaliacaoViewModel.IdTurma);
            Assert.AreEqual(1, avaliacaoViewModel.IdComponente);
            Assert.AreEqual(1, avaliacaoViewModel.IdComponente);
            Assert.AreEqual(3, avaliacaoViewModel.IdPeriodo);
            Assert.AreEqual(1, avaliacaoViewModel.Id);
        }
        [TestMethod()]
        public void DeleteTest_Get()
        {
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AvaliacaoViewModel));
            AvaliacaoViewModel avaliacaoViewModel = (AvaliacaoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(20220203, avaliacaoViewModel.DataEntrega);
            Assert.AreEqual(202202, avaliacaoViewModel.HorarioEntrega);
            Assert.AreEqual("Projeto", avaliacaoViewModel.TipoDeAtividade);
            Assert.AreEqual(0, avaliacaoViewModel.Avaliativo);
            Assert.AreEqual(1, avaliacaoViewModel.IdTurma);
            Assert.AreEqual(1, avaliacaoViewModel.IdComponente);
            Assert.AreEqual(1, avaliacaoViewModel.IdComponente);
            Assert.AreEqual(3, avaliacaoViewModel.IdPeriodo);
            Assert.AreEqual(1, avaliacaoViewModel.Id);
        }

        [TestMethod()]
        public void DeleteTest_Post()
        {
            // Act
            var result = controller.Delete(GetTargetAvaliacaoViewModel().Avaliativo, GetTargetAvaliacaoViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private Avaliacao GetTargetAvaliacao()
        {
            return new Avaliacao
            {
                Id = 1,
                DataEntrega = DateTime.Parse("2022-01-01"),
                HorarioEntrega = DateTime.Parse("20:00:00:00"),
                TipoDeAtividade = "Projeto",
                Peso = 3,
                Avaliativo = false,
                IdTurma = 1,
                IdComponente = 1,
                IdPeriodo = 1
            };
        }

        private IEnumerable<Avaliacao> GetTestAvaliacao()
        {
            return new List<Avaliacao>
            {
                 new Avaliacao
                {
                   Id = 1,
                    DataEntrega = DateTime.Parse("2022-01-01"),
                    HorarioEntrega = DateTime.Parse("20:00:00:00"),
                    TipoDeAtividade = "Projeto",
                    Peso = 3,
                    Avaliativo = false,
                    IdTurma = 1,
                    IdComponente = 1,
                    IdPeriodo = 1
                },
                new Avaliacao
                {
                    Id = 2,
                    DataEntrega = DateTime.Parse("2022-01-01"),
                    HorarioEntrega = DateTime.Parse("20:00:00:00"),
                    TipoDeAtividade = "Projeto",
                    Peso = 3,
                    Avaliativo = false,
                    IdTurma = 1,
                    IdComponente = 1,
                    IdPeriodo = 1
                },
                new Avaliacao
                {
                    Id = 3,
                    DataEntrega = DateTime.Parse("2022-01-11"),
                    HorarioEntrega = DateTime.Parse("23:00:00:00"),
                    TipoDeAtividade = "Prova",
                    Peso = 7,
                    Avaliativo = true,
                    IdTurma = 1,
                    IdComponente = 1,
                    IdPeriodo = 1
                }
            };
        }

        private AvaliacaoViewModel GetTargetAvaliacaoViewModel()
        {
            return new AvaliacaoViewModel
            {
                DataEntrega = DateTime.Parse("2022-01-11"),
                HorarioEntrega = DateTime.Parse("23:00:00:00"),
                TipoDeAtividade = "Prova",
                Peso = 7,
                Avaliativo = 1,
                IdTurma = 1,
                IdComponente = 1,
                IdPeriodo = 1,
                Id = 1,
            };
        }

    }
}
