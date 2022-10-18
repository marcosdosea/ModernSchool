using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernSchool.Controllers;
using ModernSchool.Mappers;
using ModernSchool.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernSchool.Controllers.Tests
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
            throw new NotImplementedException();
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
            var result = controller.Edit(GetTargetAnoLetivoViewModel().Id, GetTargetAnoLetivoViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private object GetTargetAnoLetivoViewModel()
        {
            throw new NotImplementedException();
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
            var result = controller.Delete(GetTargetAnoLetivoViewModel().Id, GetTargetAnoLetivoViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
        private Anoletivo GetTargetAnoLetivo()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Anoletivo> GetTestAnosLetivos()
        {
            throw new NotImplementedException();
        }
    }
}