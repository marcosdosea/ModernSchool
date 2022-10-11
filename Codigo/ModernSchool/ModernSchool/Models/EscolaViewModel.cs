using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class EscolaViewModel
    {
        [Required(ErrorMessage = "Campo requerido")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(70, ErrorMessage = "No minímo 10 caracteres e no máximo 70.", MinimumLength = 10)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(14, ErrorMessage = "No minímo 14 caracteres e no máximo 14.", MinimumLength = 14)]
        public string Cnpj { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public short? Numero { get; set; }
        [Required(ErrorMessage = "Campo requirido")]
        public int IdGoverno { get; set; }
    }
}
