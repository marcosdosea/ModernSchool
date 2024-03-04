using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class CurriculoViewModel
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }
        [Display(Name = "Escolaridade")]
        [Required(ErrorMessage = "Campo escolaridade é obrigatório")]
        [StringLength(1, ErrorMessage = "O nome da escolaridade deve ter no máximo 1 caracter")]
        public string? Escolaridade { get; set; }
        [Display(Name = "Ano faixa")]
        [Required(ErrorMessage = "Campo ano faixa é obrigatório")]
        [StringLength(4, ErrorMessage = "O ano faixa deve ter no máximo 4 caracteres")]
        public string? AnoFaixa { get; set; }
        [Display(Name = "Ano letivo")]
        [Required(ErrorMessage = "Campo ano letivo é obrigatório")]
        public short? AnoLetivo1 { get; set; }
        [Display(Name = "Código do governo")]
        [Required(ErrorMessage = "Campo id do governo é obrigatório")]
        public int IdGoverno { get; set; }
    }
}
