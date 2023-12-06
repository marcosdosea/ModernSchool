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
    public class AnoLetivoControllerTests
    {
        private static AnoLetivoController controller;

        [TestInitialize]
        public void Initialize()
        {
            var mockService = new Mock<IAnoLetivoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new AnoLetivoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestAnosLetivos());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetAnoLetivo());
            mockService.Setup(service => service.Edit(It.IsAny<Anoletivo>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Anoletivo>()))
                .Verifiable();
            controller = new AnoLetivoController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<AnoLetivoViewModel>));

            List<AnoLetivoViewModel> lista = (List<AnoLetivoViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AnoLetivoViewModel));
            AnoLetivoViewModel anoLetivoViewModel = (AnoLetivoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(2022, anoLetivoViewModel.AnoLetivo);
            Assert.AreEqual(1, anoLetivoViewModel.IdEscola);
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
            var result = controller.Create(GetNewAnoLetivo());

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
            var result = controller.Create(GetNewAnoLetivo());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private AnoLetivoViewModel GetNewAnoLetivo()
        {
            return new AnoLetivoViewModel
            {
                AnoLetivo = 2022,
                DataInicio = DateTime.Parse("2022-01-01"),
                DataFim = DateTime.Parse("2022-01-01"),
                IdEscola = 1
            };
        }

        [TestMethod()]
        public void EditTest_Get()
        {
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AnoLetivoViewModel));
            AnoLetivoViewModel anoLetivoViewModel = (AnoLetivoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(2022, anoLetivoViewModel.AnoLetivo);
            Assert.AreEqual(1, anoLetivoViewModel.IdEscola);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(GetTargetAnoLetivoViewModel().AnoLetivo, GetTargetAnoLetivoViewModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AnoLetivoViewModel));
            AnoLetivoViewModel anoLetivoViewModel = (AnoLetivoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(2022, anoLetivoViewModel.AnoLetivo);
            Assert.AreEqual(1, anoLetivoViewModel.IdEscola);
        }

        [TestMethod()]
        public void DeleteTest_Post()
        {
            // Act
            var result = controller.Delete(GetTargetAnoLetivoViewModel().AnoLetivo, GetTargetAnoLetivoViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private Anoletivo GetTargetAnoLetivo()
        {
            return new Anoletivo
            {
                AnoLetivo1 = 2022,
                DataInicio = DateTime.Parse("2022-01-01"),
                DataFim = DateTime.Parse("2022-11-11"),
                IdEscola = 1
            };
        }

        private IEnumerable<Anoletivo> GetTestAnosLetivos()
        {
            return new List<Anoletivo>
            {
                 new Anoletivo
                {
                    AnoLetivo1 = 2022,
                    DataInicio =  DateTime.Parse("2022-01-01"),
                    DataFim =  DateTime.Parse("2022-11-11"),
                    IdEscola = 1
                },
                new Anoletivo
                {
                    AnoLetivo1 = 2023,
                    DataInicio =  DateTime.Parse("2023-01-01"),
                    DataFim =  DateTime.Parse("2023-01-01"),
                    IdEscola = 1
                },
                new Anoletivo
                {
                    AnoLetivo1 = 2024,
                    DataInicio =  DateTime.Parse("2024-01-01"),
                    DataFim =  DateTime.Parse("2024-11-11"),
                    IdEscola = 1
                }
            };
        }

         private AnoLetivoViewModel GetTargetAnoLetivoViewModel()
        {
            return new AnoLetivoViewModel
            {
                AnoLetivo = 2023,
                DataInicio = DateTime.Parse("2023-01-01"),
                DataFim = DateTime.Parse("2023-11-11"),
                IdEscola = 1
            };
        }
    }
}