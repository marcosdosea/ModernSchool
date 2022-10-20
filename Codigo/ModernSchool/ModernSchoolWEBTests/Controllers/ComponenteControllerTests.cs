using AutoMapper;
using Core.Service;
using Core;
using ModernSchoolWEB.Models;
using ModernSchoolWEB.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernSchoolWEB.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ModernSchoolWEBTest.Controllers.Tests
{
    [TestClass()]
    public class ComponenteControllerTests
    {

        private static ComponenteController controller;

        [TestInitialize]
        public void Initialize()
        {
            var mockService = new Mock<IComponenteService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new ComponenteProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestComponente());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetComponente());
            mockService.Setup(service => service.Edit(It.IsAny<Componente>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Componente>()))
                .Verifiable();
            controller = new ComponenteController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<ComponenteViewModel>));

            List<ComponenteViewModel> lista = (List<ComponenteViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ComponenteViewModel));
            ComponenteViewModel ComponenteViewModel = (ComponenteViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, ComponenteViewModel.id);
            Assert.AreEqual("Matemática", ComponenteViewModel.nome);
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
            var result = controller.Create(GetNewComponente());

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
            var result = controller.Create(GetNewComponente());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private ComponenteViewModel GetNewComponente()
        {
            return new ComponenteViewModel
            {
                id = 1,
                nome = "Matemática"
            };
        }

        public void EditTest_Get()
        {
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ComponenteViewModel));
            ComponenteViewModel ComponenteViewModel = (ComponenteViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, ComponenteViewModel.id);
            Assert.AreEqual("Matemática", ComponenteViewModel.nome);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(GetTargetComponenteViewModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ComponenteViewModel));
            ComponenteViewModel ComponenteViewModel = (ComponenteViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, ComponenteViewModel.id);
            Assert.AreEqual("Matemática", ComponenteViewModel.nome);
        }

        public void DeleteTest_Post()
        {
            // Act
            var result = controller.Delete(GetTargetComponenteViewModel().id, GetTargetComponenteViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private Componente GetTargetComponente()
        {
            return new Componente
            {
                Id = 1,
                Nome = "Matemática"
            };
        }

        private IEnumerable<Componente> GetTestComponente()
        {
            return new List<Componente>
            {
                 new Componente
                {
                    Id = 1,
                    Nome =  "Matemática"
                },
                new Componente
                {
                    Id = 2,
                    Nome =  "Filosofia"
                },
                new Componente
                {
                    Id = 3,
                    Nome =  "Sociologia"
                }
            };
        }

        private ComponenteViewModel GetTargetComponenteViewModel()
        {
            return new ComponenteViewModel
            {
                id = 2,
                nome = "Filosofia"
            };
        }
    }
}
