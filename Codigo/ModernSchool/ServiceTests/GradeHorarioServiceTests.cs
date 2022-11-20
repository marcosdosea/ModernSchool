using Core.Service;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.DTO;

namespace Service.Tests
{
    [TestClass()]
    public class GradeHorarioServiceTests
    {


        private ModernSchoolContext _context;
        private IGradeHorarioService _gradeService;




        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<ModernSchoolContext>();
            builder.UseInMemoryDatabase("ModernSchool");
            var options = builder.Options;

            _context = new ModernSchoolContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var gradeHorario = new List<Gradehorario>
                {
                    new Gradehorario { Id = 1 , DiaSemana = "SEG", HoraFim = "9" ,HoraInicio = "7",IdComponente = 1,
                        IdProfessor = 1, IdTurma = 1},
                    new Gradehorario { Id = 2 , DiaSemana = "SEG", HoraFim = "11" ,HoraInicio = "9",IdComponente = 2,
                        IdProfessor = 2, IdTurma = 2},
                    new Gradehorario { Id = 3 , DiaSemana = "SEG", HoraFim = "13" ,HoraInicio = "11",IdComponente = 3,
                        IdProfessor = 3, IdTurma = 3},
                };

            _context.AddRange(gradeHorario);
            _context.SaveChanges();

            _gradeService = new GradeHorarioService(_context);
        }


        [TestMethod()]
        public void CreateTest()
        {
            _gradeService.Create(new Gradehorario() { Id = 4,
                DiaSemana = "SEG",
                HoraFim = "15",
                HoraInicio = "13",
                IdComponente = 4,
                IdProfessor = 4,
                IdTurma = 4
            });

            Assert.AreEqual(4, _gradeService.GetAll().Count());

            var grade = _gradeService.Get(4);
            Assert.AreEqual(4, grade.Id);
            Assert.AreEqual("SEG", grade.DiaSemana);
            Assert.AreEqual("15", grade.HoraFim);
            Assert.AreEqual("13", grade.HoraInicio);
            Assert.AreEqual(4,grade.IdComponente);
            Assert.AreEqual(4, grade.IdProfessor);
            Assert.AreEqual(4, grade.IdTurma);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            _gradeService.Delete(2);
            Assert.AreEqual(2, _gradeService.GetAll().Count());
            var grade = (_gradeService.Get(2));
            Assert.AreEqual(null, grade);
        }

        [TestMethod()]
        public void EditTest()
        {
            var grade = _gradeService.Get(3);
            grade.Id = 3;
            grade.HoraInicio = "20";
            grade.HoraFim = "22";
            grade.IdProfessor = 3;
            grade.IdComponente = 3;
            grade.IdTurma = 3;
            grade.DiaSemana = "SEG";

            //Assert

            grade = _gradeService.Get(3);

            Assert.IsNotNull(grade);
            Assert.AreEqual(3, grade.Id);
            Assert.AreEqual("20", grade.HoraInicio);
            Assert.AreEqual("22", grade.HoraFim);
            Assert.AreEqual(3, grade.IdProfessor);
            Assert.AreEqual(3, grade.IdComponente);
            Assert.AreEqual(3, grade.IdTurma);
            Assert.AreEqual("SEG",grade.DiaSemana);

        }

        [TestMethod()]
        public void GetTest()
        {
            var grade = _gradeService.Get(3);
            Assert.IsNotNull(grade);
            Assert.AreEqual(3, grade.Id);
            Assert.AreEqual("11", grade.HoraInicio);
            Assert.AreEqual("13", grade.HoraFim);
            Assert.AreEqual(3, grade.IdProfessor);
            Assert.AreEqual(3, grade.IdComponente);
            Assert.AreEqual(3, grade.IdTurma);
            Assert.AreEqual("SEG", grade.DiaSemana);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            var grade = _gradeService.GetAll();

            Assert.IsInstanceOfType(grade,typeof(IEnumerable<Gradehorario>));
            Assert.IsNotNull(grade);
            Assert.AreEqual(3, grade.Count());
            Assert.AreEqual(1, grade.First().Id);

        }

    }
}