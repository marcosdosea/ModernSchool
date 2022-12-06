using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ModernSchoolAPI.Models
{
    public class ProfessorViewModel
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
