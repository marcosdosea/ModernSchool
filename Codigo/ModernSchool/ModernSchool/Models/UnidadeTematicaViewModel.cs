using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ModernSchoolWEB.Models
{
    public class UnidadeTematicaViewModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código da unidade temática é obrigatório")]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(100, ErrorMessage = "descrição deve ter no máximo 100 caracteres")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Código do ano letivo é obrigatório")]
        public short? AnoLetivo { get; set; }
        [Required(ErrorMessage = "Código do currículo é obrigatório")]
        public int IdCurriculo { get; set; }
        [Required(ErrorMessage = "Código do componente é obrigatório")]
        public int IdComponente { get; set; }
    }
}
