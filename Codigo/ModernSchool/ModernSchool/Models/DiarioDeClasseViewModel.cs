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
        [Display(Name = "Resumo da Aula")]
        [Required(ErrorMessage = "Campo resumo da aula é obrigatório")]
        public string ResumoAula { get; set; }
        [Display(Name = "Turma")]
        [Required(ErrorMessage = "Campo turma é obrigatório")]
        public int IdTurma { get; set; }
        [Display(Name = "Componente")]
        [Required(ErrorMessage = "Campo componente é obrigatório")]
        public int IdComponente { get; set; }
        [Display(Name = "Professor")]
        [Required(ErrorMessage = "Campo professor é obrigatório")]
        public int IdProfessor { get; set; }
        public string TipoAula { get; set; }
        public virtual Componente IdComponenteNavigation { get; set; }
        public virtual Pessoa IdProfessorNavigation { get; set; }
        public virtual Turma IdTurmaNavigation { get; set; }

    }
}
