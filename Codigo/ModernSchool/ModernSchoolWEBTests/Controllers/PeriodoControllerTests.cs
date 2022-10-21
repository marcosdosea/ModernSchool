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

namespace ModernSchoolWEBTest.Controllers.Tests
{
    [TestClass()]
    public class PeriodoControllerTests
    {

        private static PeriodoController controller;

        [TestInitialize]
        public void Initialize()
        {
            var mockService = new Mock<IPeriodoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new PeriodoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestPeriodo());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetPeriodo());
            mockService.Setup(service => service.Edit(It.IsAny<Periodo>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Periodo>()))
                .Verifiable();
            controller = new PeriodoController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<PeriodoViewModel>));

            List<PeriodoViewModel> lista = (List<PeriodoViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PeriodoViewModel));
            PeriodoViewModel periodoViewModel = (PeriodoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, periodoViewModel.Id);
            Assert.AreEqual("Sexto", periodoViewModel.Nome);
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
            var result = controller.Create(GetNewPeriodo());

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
            var result = controller.Create(GetNewPeriodo());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

      

        private PeriodoViewModel GetNewPeriodo()
        {
            return new PeriodoViewModel
            {
                Id = 1,
                Nome = "Sexto"
            };
        }

        public void EditTest_Get()
        {
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PeriodoViewModel));
            PeriodoViewModel periodoViewModel = ( PeriodoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, periodoViewModel.Id);
            Assert.AreEqual("Sexto", periodoViewModel.Nome);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(GetTargetPeriodoViewModel().Id, GetTargetPeriodoViewModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PeriodoViewModel));
            PeriodoViewModel periodoViewModel = (PeriodoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, periodoViewModel.Id);
            Assert.AreEqual("Sexto", periodoViewModel.Nome);
        }

        public void DeleteTest_Post()
        {
            // Act
            var result = controller.Delete(GetTargetPeriodoViewModel().Id, GetTargetPeriodoViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private Periodo GetTargetPeriodo()
        {
            return new Periodo
            {
                Id = 1,
                Nome = "Sexto"
            };
        }

        private IEnumerable<Periodo> GetTestPeriodo()
        {
            return new List<Periodo>
            {
                 new Periodo
                {
                    Id = 1,
                    Nome =  "Sexto",
                    DataInicio = DateTime.Parse("2022-01-01"),
                    DataFim = DateTime.Parse("2022-12-12"),
                    AnoLetivo = 2022

                },
                new Periodo
                {
                    Id = 2,
                    Nome =  "Quarto",
                    DataInicio = DateTime.Parse("2021-01-01"),
                    DataFim = DateTime.Parse("2021-12-12"),
                    AnoLetivo = 2021
                },
                new Periodo
                {
                    Id = 3,
                    Nome =  "Segundo",
                    DataInicio = DateTime.Parse("2020-01-01"),
                    DataFim = DateTime.Parse("2020-12-12"),
                    AnoLetivo = 2020
                }
            };
        }

        private PeriodoViewModel GetTargetPeriodoViewModel()
        {
            return new PeriodoViewModel
            {
                Id = 2,
                Nome = "Quarto",
                DataInicio = DateTime.Parse("2021-01-01"),
                DataFim = DateTime.Parse("2021-12-12"),
                AnoLetivo = 2021
            };
        }
    }
}