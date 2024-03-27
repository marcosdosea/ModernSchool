using Core;
using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class ComunicacaoViewModel
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }
        [Display(Name = "Enviar para alunos")]
        [Required(ErrorMessage = "Campo enviar para alunos é obrigatório")]
        public byte EnviarAlunos { get; set; }
        [Display(Name = "Enviar para responsaveis")]
        [Required(ErrorMessage = "Campo Enviar para responsaveis é obrigatório")]
        public byte EnviarResponsaveis { get; set; }
        [Display(Name = "Mensagem")]
        [Required(ErrorMessage = "Campo mensagem é obrigatório")]
        [StringLength(500, ErrorMessage = "A Mensagem deve ter no máximo 500 caracteres")]
        public string? Mensagem { get; set; }
        [Display(Name = "Código da turma")]
        [Required(ErrorMessage = "Campo Código da turma faixa é obrigatório")]
        public int IdTurma { get; set; }
        [Display(Name = "Código do componente")]
        [Required(ErrorMessage = "Campo Código do componente é obrigatório")]
        public int IdComponente { get; set; }
    }
    public class ComunicacaoModel
    {
        public IEnumerable<Comunicacao> Comunicacoes { get; set; }
        public int IdTurma { get; set; }
    }
}
