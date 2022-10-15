using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class PeriodoViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(30, ErrorMessage = "O nome do período deve ter no máximo 30 caracteres")]
        public string Nome { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public int AnoLetivo { get; set; }
    }
}
