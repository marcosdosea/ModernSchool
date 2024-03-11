using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class ComponenteViewModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código do componente é obrigatório")]
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(10, ErrorMessage = "Nome do componente deve ter no máximo 10 caracteres")]
        [Display(Name = "Componente")]
        public string? nome { get; set; }
    }
}
