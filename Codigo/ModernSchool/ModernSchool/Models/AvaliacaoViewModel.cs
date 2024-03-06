using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ModernSchoolWEB.Models
{
    public class AvaliacaoViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Data Entrega")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataEntrega{ get; set; }
        [Display(Name = "Tipo de Avaliação")]
        [Required(ErrorMessage = "Campo tipo de atividade é obrigatório")]
        public string? TipoAvaliacao { get; set; }
        [Display(Name = "Peso")]
        [Required(ErrorMessage = "Campo peso é obrigatório")]
        public int Peso { get; set; }

        [Display(Name = "Avaliativo")]
        [Required(ErrorMessage = "Campo tipo de atividade é obrigatório")]
        public bool Avaliativo { get; set; }
        [Display(Name = "Turma")]
        [Required(ErrorMessage = "Campo turma é obrigatório")]
        public int IdTurma { get; set; }
        [Display(Name = "Componente")]
        [Required(ErrorMessage = "Campo componente é obrigatório")]
        public int IdComponente { get; set; }
        [Display(Name = "Período")]
        [Required(ErrorMessage = "Campo período é obrigatório")]
        public int IdPeriodo { get; set;}
        public IFormFile Arquivo { get; set; }
        public SelectList? ListaComponentes { get; set; }
        public SelectList? listaTurma { get; set; }
        public SelectList? listaPeriodo { get; set; }

        public Dictionary<String, String> listaTipoAtividade { get; } = new()
        {
            {"PROVA", "Prova" },
            {"PROJETO" , "Projeto" },
            {"ATIVIDADE", "Atividade" }
        };
    }
}
