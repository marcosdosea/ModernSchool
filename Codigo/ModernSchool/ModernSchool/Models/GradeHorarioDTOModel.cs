using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class GradeHorarioDTOModel
    {
        [Key]
        public int Id { get; set; } 

        [Display(Name ="Componente")]
        public string? Componente { get; set; }
        [Display(Name ="Dia")]
        public string? Dia { get; set; }
        [Display(Name ="Hora inicio")]
        public string? HoraInicio { get; set; }
        [Display(Name ="HoraFim fim")]
        public string? HoraFim { get; set; }
        [Display(Name ="Professor")]
        public string? Professor { get; set; }
    }
}
