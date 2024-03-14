using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class GradehorarioViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Componente")]
        public int IdComponente { get; set; }
        [Required]
        [Display(Name = "Turma")]
        public int IdTurma { get; set; }
      
        [Required (ErrorMessage ="Este campo é requerido")]
        [Display(Name = "Dia da Semana")]
        public string? DiaSemana { get; set; }
        [Required(ErrorMessage = "Este campo é requerido")]
        [RegularExpression(@"^(?:[01]\d|2[0-3]):[0-5]\d$", ErrorMessage = "Formato Inválido! Ex:23:59")]
        [Display(Name = "Hora Início", Prompt = "Ex: 23:59")]
        public string? HoraInicio { get; set; }
        [Required(ErrorMessage = "Este campo é requerido")]
        [RegularExpression(@"^(?:[01]\d|2[0-3]):[0-5]\d$", ErrorMessage = "Formato Inválido! Ex: 23:59")]
        [Display(Name = "Hora Fim", Prompt = "Ex: 23:59")]
        public string? HoraFim { get; set; }
        [Required]
        [Display(Name = "Professor")]
        public int IdProfessor { get; set; }
        public string NomeEscola {  get; set; }
        public string Turma { get; set; }
        public string Sala { get; set; }
        public SelectList? ListaComponentes { get; set; }

        public SelectList? ListaTurma { get; set; } 

        public SelectList? ListaProfessor { get;set; }

        public Dictionary<string, string> dias { get; } = new()
        {
            {"DOM","Domingo" },
            {"SEG","Segunda-Feira" },
            {"TER","Terça-Feira" },
            {"QUA","Quarta-Feira" },
            {"QUI","Quinta-Feira" },
            {"SEX","Sexta-Feira" },
            {"SAB","Sábado" }
        };

    }
}