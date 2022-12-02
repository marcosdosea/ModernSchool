using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class ProfessorDTOModel
    {
        [Key]
        [Display(Name = "Id")]
        public int IdPessoa { get; set; }
        [Display(Name = "Nome")]
        public string NomePessoa { get; set; }
        [Display(Name = "Cargo")]
        public string CargoPessoa { get; set; }
    }
}
