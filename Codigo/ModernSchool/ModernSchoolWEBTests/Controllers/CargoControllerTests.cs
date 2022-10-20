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
    public class CargoControllerTests
    {
        private static CargoController controller;

        [TestInitialize]
        public void Initialize()
        {
            var mockService = new Mock<ICargoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new CargoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestCargos());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetCargos());
            mockService.Setup(service => service.Edit(It.IsAny<Cargo>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Cargo>()))
                .Verifiable();
            controller = new CargoController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<CargoViewModel>));

            List<CargoViewModel> lista = (List<CargoViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CargoViewModel));
            CargoViewModel CargoViewModel = (CargoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, CargoViewModel.IdCargo);
            Assert.AreEqual("Faxineiro", CargoViewModel.Descricao);
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
            var result = controller.Create(GetNewCargo());

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
            var result = controller.Create(GetNewCargo());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private CargoViewModel GetNewCargo()
        {
            return new CargoViewModel
            {
                IdCargo = 1,
                Descricao = "Faxineiro"
            };
        }

        [TestMethod()]
        public void EditTest_Get()
        {
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CargoViewModel));
            CargoViewModel CargoViewModel = (CargoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, CargoViewModel.IdCargo);
            Assert.AreEqual("Faxineiro", CargoViewModel.Descricao);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(GetTargetCargoViewModel().IdCargo, GetTargetCargoViewModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CargoViewModel));
            CargoViewModel CargoViewModel = (CargoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, CargoViewModel.IdCargo);
            Assert.AreEqual("Faxineiro", CargoViewModel.Descricao);
        }

        [TestMethod()]
        public void DeleteTest_Post()
        {
            // Act
            var result = controller.Delete(GetTargetCargoViewModel().IdCargo, GetTargetCargoViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private Cargo GetTargetCargos()
        {
            return new Cargo
            {
                IdCargo = 1,
                Descricao = "Faxineiro"
            };
        }

        private IEnumerable<Cargo> GetTestCargos()
        {
            return new List<Cargo>
            {
                 new Cargo
                {
                    IdCargo = 1,
                    Descricao =  "Faxineiro"
                },
                new Cargo
                {
                    IdCargo = 2,
                    Descricao =  "Cozinheira"
                },
                new Cargo
                {
                    IdCargo = 3,
                    Descricao =  "Professor"
                }
            };
        }

        private CargoViewModel GetTargetCargoViewModel()
        {
            return new CargoViewModel
            {
                IdCargo = 2,
                Descricao = "Cozinheiro"
            };
        }
    }
}
