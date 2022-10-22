using Core.Service;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Service;

namespace ServiceTests
{
    [TestClass()]
    public class AvaliacaoServiceTests
    {
        private ModernSchoolContext _context;
        private IAvaliacaoService _avaliacaoService;
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
            var avaliacoes = new List<Avaliacao>
                {
                   new Avaliacao { Id = 1, DataEntrega = DateTime.Parse("2022-10-01"), HorarioEntrega = DateTime.Parse("00:00:00"), TipoDeAtividade = "Prova", Peso = 3, Avaliativo = true, IdTurma = 1, IdComponente = 1, IdPeriodo = 1},
                   new Avaliacao { Id = 2, DataEntrega = DateTime.Parse("2022-11-20"), HorarioEntrega = DateTime.Parse("23:59:00"), TipoDeAtividade = "Projeto", Peso = 3, Avaliativo = false, IdTurma = 1, IdComponente = 1, IdPeriodo = 1},
                   new Avaliacao { Id = 3, DataEntrega = DateTime.Parse("2022-12-30"), HorarioEntrega = DateTime.Parse("00:00:00"), TipoDeAtividade = "Projeto", Peso = 3, Avaliativo = false, IdTurma = 1, IdComponente = 1, IdPeriodo = 1},

                };

            _context.AddRange(avaliacoes);
            _context.SaveChanges();

            _avaliacaoService = new AvaliacaoService(_context);
        }
    }
}
