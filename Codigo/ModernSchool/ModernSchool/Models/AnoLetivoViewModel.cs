using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class AnoLetivoViewModel
    {
        [Key]
        [Display(Name = "Ano Letivo")]
        [Required(ErrorMessage = "Campo ano letivo é obrigatório")]
        public int AnoLetivo { get; set; }
        [Required(ErrorMessage = "Campo escola é obrigatório")]
        [Display(Name = "Escola")]
        public int? IdEscola { get; set; }
        [Display(Name = "Data de início")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataInicio { get; set; }

        [Display(Name = "Data de fim")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataFim { get; set; }
    }
}
