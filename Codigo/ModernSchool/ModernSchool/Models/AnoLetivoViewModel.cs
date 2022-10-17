using System.ComponentModel.DataAnnotations;

namespace ModernSchool.Models
{
    public class AnoLetivoViewModel
    {
        [Key]
        [Display(Name = "Ano Letivo")]
        [Required(ErrorMessage = "Campo requerido")]
        public int AnoLetivo { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Escola")]
        public int IdEscola { get; set; }
        [Display(Name = "Data de início")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataInicio { get; set; }
        [Display(Name = "Data de fim")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataFim { get; set; }
    }
}
