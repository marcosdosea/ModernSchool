using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class GovernoServidorModel
    {
        [Display(Name = "Cargo")]
        public int IdCargo { get; set; }

        [Display(Name ="Data de inicio")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataInicio { get; set; }

        [Display(Name ="Data de término")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataFim { get; set; }

        [Display(Name ="Situação")]
        public string? Status { get; set; }

        [Display(Name ="Governo")]
        public int IdGoverno { get; set; }

        [Display(Name ="Professor")]
        public int IdPessoa { get; set; }
    }
}
