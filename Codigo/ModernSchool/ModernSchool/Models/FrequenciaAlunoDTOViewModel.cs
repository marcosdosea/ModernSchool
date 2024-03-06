using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ModernSchoolWEB.Models
{
    public class FrequenciaAlunoDTOViewModel
    {
        [Display(Name = "Matrícula")]
        public int IdAluno { get; set; }
        [Display(Name = "Nome")]
        [StringLength(70, ErrorMessage = "No minímo 10 caracteres e no máximo 70.", MinimumLength = 10)]
        public string? NomeAluno { get; set; }
        [Range(0, 5, ErrorMessage = "O Número deve estar entre 0 e 5")]
        public int Faltas { get; set; }
        public int IdDiario { get; set; }
    }
    public class FrequenciaListaAlunoDTOViewModel
    {
        public List<FrequenciaAlunoDTOViewModel> Lista { get; set; }
        public int IdTurma { get; set; }
        public int IdComponente { get; set; }
    }
}
