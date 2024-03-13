using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class TurmaViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Ano Letivo")]
        public int AnoLetivo1 { get; set; }
        [Display(Name = "Turma")]
        public string? Turma1 { get; set; }
        public int Vagas { get; set; }
        [Display(Name = "Matriculados")]
        public int VagasDisponiveis { get; set; }
        public string? Sala { get; set; }
        public string? Escolaridade { get; set; }
        public string? Status { get; set; }
        public SelectList ?ListaAnoLetivo {get; set;}
        public string NomeEscola { get; set; } = string.Empty;
        public IEnumerable<TurmaViewModel> ListaTurma;
    }

}
