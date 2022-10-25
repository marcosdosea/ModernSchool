using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ModernSchoolWEB.Models
{
    public class ObjetoDeConhecimentoViewModel
    {
      
        [Display(Name = "Código")]
        [Key]
        public int Id { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo descrição é obrigatório")]
        [StringLength(100, ErrorMessage = "A descrição deve ter no máximo 45 caracteres")]
        public string? Descricao { get; set; }
        [Required(ErrorMessage = "Campo unidade temática é obrigatório")]
        [Display(Name = "Unidade Temática")]
        public int IdUnidadeTematica { get; set; }
        [Required(ErrorMessage = "Campo sequêcia proposta é obrigatório")]
        [Display(Name = "Sequência Proposta")]
        public int SequenciaProposta { get; set; }
    
    }
}
