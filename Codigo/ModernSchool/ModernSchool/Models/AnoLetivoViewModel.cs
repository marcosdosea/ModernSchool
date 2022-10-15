using System.ComponentModel.DataAnnotations;

namespace ModernSchool.Models
{
    public class AnoLetivoViewModel
    {
        [Key]
        [Required(ErrorMessage = "Campo requerido")]
        public int AnoLetivo { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public int IdEscola { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo requerido")]
        public DateTime DataInicio { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo requerido")]  
        public DateTime DataFim { get; set; }
    }
}
