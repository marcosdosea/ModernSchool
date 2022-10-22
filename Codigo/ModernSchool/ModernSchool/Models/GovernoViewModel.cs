using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class GovernoViewModel
    {
        [Key]
        [Display(Name = "Codigo")]
        public int Id { get; set; }
        
        [Display(Name = "Municipio")]
        [Required(ErrorMessage ="O nome do municipio é necessário")]
        [StringLength(30,MinimumLength = 5, ErrorMessage = "A quantidade de caracteres não é aceitavel")]
        public string Municipio { get; set; }
        
        [Display (Name = "Estado")]
        [Required(ErrorMessage =" Inserir as siglas do Estado")]
        [StringLength(2,MinimumLength =2 , ErrorMessage = "É necessário dois caracteres")]
        public string? Estado { get; set; }
        
        [Display (Name = "Dependencia Administrativa")]
        [Required(ErrorMessage ="Campo necessario ")]
        [StringLength(1,MinimumLength = 1)]
        public string? DependenciaAdministrativa { get; set; }
    }
}
