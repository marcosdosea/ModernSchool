using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class PeriodoViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(30, ErrorMessage = "O nome do período deve ter no máximo 30 caracteres")]
        public string? Nome { get; set; }
        [Display(Name = "Data de Início")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataInicio { get; set; }
        [Display(Name = "Data de Fim")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataFim { get; set; }
        [Required(ErrorMessage = "Campo ano Letivo é obrigatório")]
        [Display(Name = "Ano Letivo")]
        public int? AnoLetivo1 { get; set; }
    }
}
