using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernSchool.Controllers;
using ModernSchoolWEB.Models;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernSchool.Controllers.Tests
{
    [TestClass()]
    public class GradeHorarioControllerTests
    {

        private static GradeHorarioController _controller;  


        [TestMethod()]
        public void GradeHorarioControllerTest()
        {
            Assert.Fail();
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
        public void EditTest()
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
        public void EditTest1()
        {
            var result = _controller.Delete(GetTargetGradeHorarioViewModel().Id, GetTargetGradeHorarioViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest()
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
            Assert.AreEqual(1, gradeHorarioViewModel.IdTurma);
        }

        [TestMethod()]
        public void DeleteTest1()
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