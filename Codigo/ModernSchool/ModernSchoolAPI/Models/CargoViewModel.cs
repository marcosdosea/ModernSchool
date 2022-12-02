using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class CargoViewModel
    {
        [Key]
        [Display(Name = "Código")]
        public int IdCargo { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo descrição é obrigatório")]
        [StringLength(45, ErrorMessage = "A descrição deve ter no máximo 45 caracteres")]
        public string? Descricao { get; set; }
    }
}
