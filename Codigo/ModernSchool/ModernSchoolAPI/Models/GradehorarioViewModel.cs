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
        [Display(Name = "Hora Inicio")]
        public string? HoraInicio { get; set; }
        [Required(ErrorMessage = "Este campo é requerido")]
        [Display(Name = "Hora Fim")]
        public string? HoraFim { get; set; }
        [Required]
        [Display(Name = "Professor")]
        public int IdProfessor { get; set; }

        public SelectList? ListaComponentes { get; set; }

        public SelectList? ListaTurma { get; set; } 

        public SelectList? ListaProfessor { get;set; }

    }
}