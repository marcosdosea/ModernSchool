using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class TurmaViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Ano Letivo")]
        public int AnoLetivo { get; set; }
        [Display(Name = "Turma", Prompt = "Ex: 1° A")]
        [RegularExpression(@"^\d+[°ºªᵒo]? [A-Za-z]$", ErrorMessage = "Formato inválido. Siga este exemplo 1° A")]
        public string? Turma1 { get; set; }
        public int Vagas { get; set; }
        [Display(Name = "Matriculados")]
        public int VagasDisponiveis { get; set; }
        [Display(Prompt = "Ex: 108")]
        public string? Sala { get; set; }
        public string? Escolaridade { get; set; }
        public string? Status { get; set; }
        public SelectList ?ListaAnoLetivo {get; set;}
        public string NomeEscola { get; set; } = string.Empty;
        public IEnumerable<TurmaViewModel> ListaTurma;
    }

}
