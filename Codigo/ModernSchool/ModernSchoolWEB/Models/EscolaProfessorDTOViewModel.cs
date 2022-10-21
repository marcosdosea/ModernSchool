using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class EscolaProfessorDTOViewModel
    {
        [Key]
        public int IdTurma { get; set; }
        [Display(Name = "Escola")]
        public string? NomeEscola { get; set; }
        [Display(Name = "Componente")]
        public string? NomeComponente { get; set; }
        [Display(Name = "Turma")]
        public string? NomeTurma { get; set; }
    }
}
