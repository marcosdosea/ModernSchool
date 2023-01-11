using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ModernSchoolWEB.Models
{
    public class FrequenciaAlunoDTOViewModel
    {
        public int idAluno { get; set; }
        [Display(Name = "Matricula")]
        public int idDiarioDeClasse { get; set; }
        public int faltas { get; set; }
        [Display(Name = "Faltas")]
        [Required(ErrorMessage = "Marcar presença")]
        public string? nomeAluno { get; set; }
        [Display(Name = "Nome")]
        public string? turma { get; set; }
        public string? componente { get; set; }
    }
}
