using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class GradeHorarioDTOModel
    {
        [Key]
        public int Id { get; set; } 

        [Display(Name ="Componente")]
        public string? Componente { get; set; }
        [Required(ErrorMessage = "Este campo é requerido")]
        [Display(Name ="Dia")]
        public string? Dia { get; set; }
        [Required(ErrorMessage ="Este campo é requerido")]
        [Display(Name ="Hora inicio")]
        public string? HoraInicio { get; set; }
        [Required(ErrorMessage = "Este campo é requerido")]
        [Display(Name ="Hora Fim")]
        public string? HoraFim { get; set; }
        [Required(ErrorMessage = "Este campo é requerido")]
        [Display(Name ="Professor")]
        public string? Professor { get; set; }
    }
}
