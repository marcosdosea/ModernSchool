using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ModernSchoolWEB.Models
{
    public class AlunoAvaliacaoDTOModel
    {
        [Display(Name = "Id Avaliacao")]
        public int IdAvaliacao { get; set; }
        [Display(Name = "Matricula")]
        public int IdAluno { get; set; }
        [Display(Name = "Nome Aluno")]
        public string NomeAluno { get; set; }
        public decimal Nota { get; set; }
    }
}
