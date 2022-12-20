using Core;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ModernSchoolWEB.Models
{
    public class DiarioDeClasseViewModel
    {
        public int Id { get; set; }
        public bool? DataShow { get; set; }
        public bool? Livros { get; set; }
        public bool? LivrosSeduc { get; set; }
        public string? ResumoAula { get; set; }
        public int IdTurma { get; set; }
        public int IdComponente { get; set; }
        public int IdProfessor { get; set; }
        public string? TipoAula { get; set; }
    }
}