using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class GovernoViewModel
    {
        [Key]
        [Display(Name = "Codigo")]
        public int Id { get; set; }
        
        [Display(Name = "Municipio")]
        [Required(ErrorMessage ="O campo município é obrigatório")]
        [StringLength(30,MinimumLength = 5, ErrorMessage = "No minímo 5 caracteres e no máximo 30.")]
        public string Municipio { get; set; }
        
        [Display (Name = "Estado")]
        [Required(ErrorMessage ="O campo estado é obrigatório")]
        [StringLength(2,MinimumLength =2 , ErrorMessage = "É necessário dois caracteres")]
        public string? Estado { get; set; }
        
        [Display (Name = "Dependencia Administrativa")]
        [Required(ErrorMessage ="O campo Dependencia Administrativa é obrigatório")]
        [StringLength(1,MinimumLength = 1)]
        public string? DependenciaAdministrativa { get; set; }
    }
}
