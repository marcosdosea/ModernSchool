using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class EscolaViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nome da escola")]
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(70, ErrorMessage = "No minímo 10 caracteres e no máximo 70.", MinimumLength = 10)]
        public string? Nome { get; set; }
        [Display(Name = "cnpj")]
        [Required(ErrorMessage = "Campo cnpj é obrigatório")]
        [StringLength(14, ErrorMessage = "No minímo 14 caracteres e no máximo 14.", MinimumLength = 14)]
        public string? Cnpj { get; set; }
        [Display(Name = "rua")]
        [StringLength(50, ErrorMessage = "No minímo 1 caracteres e no máximo 50.", MinimumLength = 1)]
        public string? Rua { get; set; }
        [Display(Name = "bairro")]
        [StringLength(40, ErrorMessage = "No minímo 1 caracteres e no máximo 40.", MinimumLength = 1)]
        public string? Bairro { get; set; }
        [Display(Name = "numero")]
        public short? Numero { get; set; }
        [Required(ErrorMessage = "Campo governo é obrigatório")]
        public int IdGoverno { get; set; }
        [Required(ErrorMessage ="Campo Diretor é obrigatório")]
        public int IdDiretor { get; set; } 
    }
}
