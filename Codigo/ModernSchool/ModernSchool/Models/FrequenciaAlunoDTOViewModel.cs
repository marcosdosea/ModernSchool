using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ModernSchoolWEB.Models
{
    public class FrequenciaAlunoDTOViewModel
    {
        [Display(Name = "Matricula")]
        public int idAluno { get; set; }
        public int idDiarioDeClasse { get; set; }
        [Display(Name = "Faltas")]
        public int faltas { get; set; }
        [Display(Name = "Nome")]
        public string? nomeAluno { get; set; }
        [Display(Name = "Turma")]
        public string? turma { get; set; }
        [Display(Name = "Presença")]
        public Boolean presente { get; set; }
        [Display(Name = "Componente")]
        public string? componente { get; set; }
    }
}
