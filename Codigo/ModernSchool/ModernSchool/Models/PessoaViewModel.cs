using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ModernSchoolWEB.Models
{
    public class PessoaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo CPF é Obrigatório")]
        [Display(Name = "CPF", Prompt = "Ex: 000.000.000-00")]
        public string Cpf { get; set; } = string.Empty;
        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Campo Data de Nascimento é Obrigatório")]
        public DateTime DataNascimento { get; set; }
        [Display(Name = "CEP", Prompt = "Ex: 00000-000")]
        [Required(ErrorMessage = "Campo CEP é Obrigatório")]
        public string Cep { get; set; } = string.Empty;
        [Display(Prompt = "Ex: Nome da Rua")]
        public string? Rua { get; set; }
        [Required(ErrorMessage = "Campo Bairro é Obrigatório")]
        [Display(Prompt = "Ex: Nome do Bairro")]
        public string Bairro { get; set; } = string.Empty;
        [Display(Name = "Número", Prompt = "Ex: 60")]
        public short? Numero { get; set; }
        [Display(Name = "E-mail", Prompt = "Ex: email@xemplo.com")]
        [Required(ErrorMessage = "Campo E-mail é Obrigatório")]
        public string Email { get; set; } = string.Empty;
        public int IdTurma { get; set; }
        [Display(Name = "UF", Prompt = "Ex: Sergipe")]
        [Required(ErrorMessage = "Campo UF é Obrigatório")]
        public string Uf { get; set; } = string.Empty;
        [Display(Prompt = "Ex: Nome da Cidade")]
        public string Cidade { get; set; } = string.Empty;
        [Display(Prompt = "Ex: Ponto de referência")]
        public string? Complemento { get; set; }
        [Display(Name = "Telefone 1", Prompt = "Ex: (99)9 9999-9999")]
        [Required(ErrorMessage = "Campo Telefone 1 é Obrigatório")]
        public string Telefone1 { get; set; } = string.Empty;
        [Display(Name = "Telefone 2", Prompt = "Ex: (99)9 9999-9999")]
        public string? Telefone2 { get; set; }

    }
}
