using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ModernSchoolWEB.Models
{
    public class AvaliacaoViewModel
    {

        public int Id { get; set; }
        [Key]
        [Display(Name = "Data Entrega")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataEntrega{ get; set; }
        [Display(Name = "Horário Entrega")]
        [DataType(DataType.Date, ErrorMessage = "Horário válido requerido")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime HorarioEntrega{ get; set; }
        [Display(Name = "Tipo de Atividade")]
        [Required(ErrorMessage = "Campo tipo de atividade é obrigatório")]
        public string? TipoDeAtividade { get; set; }
        [Display(Name = "Peso")]
        [Required(ErrorMessage = "Campo peso é obrigatório")]
        public int Peso { get; set; }

        [Display(Name = "Tipo de Atividade")]
        [Required(ErrorMessage = "Campo tipo de atividade é obrigatório")]
        public int Avaliativo { get; set; }
        [Display(Name = "Turma")]
        [Required(ErrorMessage = "Campo turma é obrigatório")]
        public int IdTurma { get; set; }
        [Display(Name = "Componente")]
        [Required(ErrorMessage = "Campo componente é obrigatório")]
        public int IdComponente { get; set; }
        [Display(Name = "Período")]
        [Required(ErrorMessage = "Campo período é obrigatório")]
        public int IdPeriodo { get; set;}
        public SelectList? ListaComponentes { get; set; }
    }
}
