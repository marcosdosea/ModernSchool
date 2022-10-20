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
    public class GovernoControllerTests
    {
        
        private static GovernoController controller;

        [TestInitialize]
        public void Initialize()
        {
            var mockService = new Mock<IGovernoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new GovernoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestGovernos());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetGovernos());
            mockService.Setup(service => service.Edit(It.IsAny<Governo>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Governo>()))
                .Verifiable();
            controller = new GovernoController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<GovernoViewModel>));

            List<GovernoViewModel> lista = (List<GovernoViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(GovernoViewModel));
            GovernoViewModel governoViewModel = (GovernoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, governoViewModel.Id);
            Assert.AreEqual("itabaiana", governoViewModel.Municipio);
            Assert.AreEqual("SE", governoViewModel.Estado);
            Assert.AreEqual("M", governoViewModel.DependenciaAdministrativa);
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
            var result = controller.Create(GetNewGoverno());

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
            var result = controller.Create(GetNewGoverno());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private GovernoViewModel GetNewGoverno()
        {
            return new GovernoViewModel
            {
                Id = 1,
                Municipio = "itabaiana",
                Estado = "SE",
                DependenciaAdministrativa = "M"
            };
        }

        [TestMethod()]
        public void EditTest_Get()
        {
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(GovernoViewModel));
            GovernoViewModel governoViewModel = (GovernoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, governoViewModel.Id);
            Assert.AreEqual("itabaiana", governoViewModel.Municipio);
            Assert.AreEqual("SE", governoViewModel.Estado);
            Assert.AreEqual("M", governoViewModel.DependenciaAdministrativa);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(GetTargetGovernoViewModel().Id, GetTargetGovernoViewModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(GovernoViewModel));
            GovernoViewModel governoViewModel = (GovernoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, governoViewModel.Id);
            Assert.AreEqual("itabaiana", governoViewModel.Municipio);
            Assert.AreEqual("SE", governoViewModel.Estado);
            Assert.AreEqual("M", governoViewModel.DependenciaAdministrativa);
        }

        [TestMethod()]
        public void DeleteTest_Post()
        {
            // Act
            var result = controller.Delete(GetTargetGovernoViewModel().Id, GetTargetGovernoViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private Governo GetTargetGovernos()
        {
            return new Governo
            {
                Id = 1,
                Municipio = "itabaiana",
                Estado = "SE",
                DependenciaAdministrativa = "M"
            };
        }

        private IEnumerable<Governo> GetTestGovernos()
        {
            return new List<Governo>
            {
                 new Governo
                {
                    Id = 1,
                    Municipio = "itabaiana",
                    Estado = "SE",
                    DependenciaAdministrativa = "M"
                },
                new Governo
                {
                   Id = 2,
                   Municipio = "campo do brito",
                   Estado = "SE",
                   DependenciaAdministrativa = "M"
                },
                new Governo
                {
                   Id = 3,
                   Municipio = "Macambira",
                   Estado = "SE",
                   DependenciaAdministrativa = "E",

                }
            };
        }

        private GovernoViewModel GetTargetGovernoViewModel()
        {
            return new GovernoViewModel
            {
                Id = 2,
                Municipio = "campo do brito",
                Estado = "SE",
                DependenciaAdministrativa = "M"
            };
        }
    }
}