using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ModernSchoolWEB.Models
{
    public class AlunoAvaliacaoDTOModel
    {
        [Display(Name = "Id Aluno")]
        public int IdAluno { get; set; }
        [Display(Name = "Id Avaliacao")]
        public int IdAvaliacao { get; set; }
        public decimal Nota { get; set; }
        [Display(Name = "Data da entrega")]
        public DateTime DataEntrega { get; set; }
        [Display(Name = "Material de envio")]
        public byte[] Arquivo { get; set; }
        [Display(Name = "Nome Aluno")]
        public string NomeAluno { get; set; }
        [Display(Name = "Nome Turma")]
        public string NomeTurma { get; set; }
        [Display(Name = "Avaliativo")]
        public bool isAvaliativo { get; set; }
    }
}
