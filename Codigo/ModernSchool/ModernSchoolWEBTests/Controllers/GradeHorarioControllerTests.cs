using AutoMapper;
using Core;
using Core.DTO;
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
    public class GradeHorarioControllerTests
    {

        private static GradeHorarioController  _controller;


        [TestInitialize]
        public void Initialize()
        {
            var mockService = new Mock<IGradeHorarioService>();
            var mockServicePessoa = new Mock<IPessoaService>();
            var mockServiceComponente = new Mock<IComponenteService>();
            var mockServiceTurma = new Mock<ITurmaService>();

            MapperConfiguration mapperConfig = new MapperConfiguration(
            cfg =>
            {
                cfg.AddProfile(new GradeHorarioProfile());
                cfg.AddProfile(new PessoaProfile());
                cfg.AddProfile(new ComponenteProfile());
                cfg.AddProfile(new TurmaProfile());
            });
            IMapper mapper = new Mapper(mapperConfig);


            mockService.Setup(service => service.GetAll())
                .Returns(GetTestGradeHorario());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetGradeHorario());
            mockService.Setup(service => service.Edit(It.IsAny<Gradehorario>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Gradehorario>()))
                .Verifiable();
            
            mockServiceComponente.Setup(service => service.GetAll())
                .Returns(GetTestComponente());

            mockServicePessoa.Setup(service => service.GetAll())
                .Returns(GetTestPessoa);

            mockServiceTurma.Setup(service => service.GetAll())
                .Returns(GetTestTurma());
   
            _controller = new GradeHorarioController(mockService.Object,mapper,mockServiceComponente.Object
                ,mockServiceTurma.Object,mockServicePessoa.Object);
        }

        [TestMethod()]
        public void IndexTest()
        {
            var result = _controller.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model,typeof(List<GradehorarioViewModel>));
            List<GradehorarioViewModel> lista = (List<GradehorarioViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            var result = _controller.Details(1);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(GradehorarioViewModel));
            GradehorarioViewModel gradeHorarioViewModel = (GradehorarioViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, gradeHorarioViewModel.Id);
            Assert.AreEqual("SEG", gradeHorarioViewModel.DiaSemana);
            Assert.AreEqual("7", gradeHorarioViewModel.HoraInicio);
            Assert.AreEqual("10", gradeHorarioViewModel.HoraFim);
            Assert.AreEqual(1, gradeHorarioViewModel.IdComponente);
            Assert.AreEqual(1, gradeHorarioViewModel.IdProfessor);
        }

        [TestMethod()]
        public void CreateTest()
        {
            var result = _controller.Create();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void CreateTest_Post_Valid()
        {
            //Act
            var result = _controller.Create(GetNewGradeHorario());
            // Assert
           
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        public void CreateTest_Post_inValid()
        {

            _controller.ModelState.AddModelError("Nome", "Campo requerido");

            //Act
            var result = _controller.Create(GetNewGradeHorario());
            // Assert
            Assert.AreEqual(1, _controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }



        private GradehorarioViewModel GetNewGradeHorario()
        {
            return new GradehorarioViewModel
            {
                Id = 1,
                DiaSemana = "SEG",
                HoraInicio = "7",
                HoraFim = "10",
                IdComponente = 1,
                IdProfessor = 1,
                IdTurma = 1
            };
        }

        [TestMethod()]
        public void EditTest_Get()
        {
            var result = _controller.Edit(1);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(GradehorarioViewModel));
            GradehorarioViewModel gradeHorarioViewModel = (GradehorarioViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, gradeHorarioViewModel.Id);
            Assert.AreEqual("SEG", gradeHorarioViewModel.DiaSemana);
            Assert.AreEqual("7", gradeHorarioViewModel.HoraInicio);
            Assert.AreEqual("10", gradeHorarioViewModel.HoraFim);
            Assert.AreEqual(1, gradeHorarioViewModel.IdComponente);
            Assert.AreEqual(1, gradeHorarioViewModel.IdProfessor);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            var result = _controller.Delete(GetTargetGradeHorarioViewModel().Id, GetTargetGradeHorarioViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            var result = _controller.Delete(1);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(GradehorarioViewModel));
            GradehorarioViewModel gradeHorarioViewModel = (GradehorarioViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, gradeHorarioViewModel.Id);
            Assert.AreEqual("SEG", gradeHorarioViewModel.DiaSemana);
            Assert.AreEqual("7", gradeHorarioViewModel.HoraInicio);
            Assert.AreEqual("10", gradeHorarioViewModel.HoraFim);
            Assert.AreEqual(1, gradeHorarioViewModel.IdComponente);
            Assert.AreEqual(1, gradeHorarioViewModel.IdProfessor);
        }

        [TestMethod()]
        public void DeleteTest_Post()
        {
            var result = _controller.Delete(GetTargetGradeHorarioViewModel().Id, GetTargetGradeHorarioViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private Gradehorario GetTargetGradeHorario()
        {
            return new Gradehorario
            {
                Id = 1,
                DiaSemana = "SEG",
                HoraInicio = "7",
                HoraFim = "10",
                IdComponente = 1,
                IdProfessor = 1,
                IdTurma = 1
            };
        }


        private IEnumerable<Pessoa> GetTestPessoa()
        {
            return new List<Pessoa>
            {
                new Pessoa
                {
                    Id = 1

                    
                },
                new Pessoa
                {
                    Id = 2

                },
                new Pessoa
                {
                    Id = 3
                }
            };
        }

        private IEnumerable<Componente> GetTestComponente()
        {
            return new List<Componente>
            {
                new Componente
                {
                   Id = 1,
                   Nome = "matematica"
                },
                new Componente
                {
                    Id = 2,
                    Nome = "portugues"
                },
                new Componente
                {
                    Id = 3,
                    Nome = "geografia"
                }
            };
        }

        private IEnumerable<Turma> GetTestTurma()
        {
            return new List<Turma>
            {
                new Turma
                {
                    Id = 1
                },
                new Turma
                {
                    Id = 2,
                },
                new Turma { Id = 3 }
            };
        }

        private IEnumerable<Gradehorario> GetTestGradeHorario()
        {
            return new List<Gradehorario>
            {
                new Gradehorario
                {
                    Id = 1,
                    DiaSemana = "SEG",
                    HoraInicio = "7",
                    HoraFim = "10",
                    IdComponente = 1,
                    IdProfessor = 1,
                    IdTurma = 1
                },
                new Gradehorario
                {
                   Id = 2,
                   DiaSemana = "SEG",
                   HoraInicio = "10",
                   HoraFim = "13",
                   IdComponente = 2,
                   IdProfessor = 2,
                   IdTurma = 2
                },
                new Gradehorario
                {
                   Id = 3,
                   DiaSemana = "SEG",
                   HoraInicio = "13",
                   HoraFim = "14",
                   IdComponente = 3,
                   IdProfessor = 3,
                   IdTurma = 3
                }
            };
        }

        private GradehorarioViewModel GetTargetGradeHorarioViewModel()
        {
            return new GradehorarioViewModel
            {
                Id = 2,
                DiaSemana = "SEG",
                HoraInicio = "10",
                HoraFim = "13",
                IdComponente = 2,
                IdProfessor = 2,
                IdTurma = 2
            };
        }


    }
}