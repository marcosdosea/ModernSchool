using AutoMapper;
using Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernSchool.Controllers;
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
                cfg.AddProfile(new AnoletivoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestAreasDeServico());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetAreaDeServico());
            mockService.Setup(service => service.Edit(It.IsAny<Areadeservico>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Areadeservico>()))
                .Verifiable();
            controller = new AreaDeServicoController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DetailsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            Assert.Fail();
        }
    }
}