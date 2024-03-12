using Core.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
namespace ModernSchoolWEB.Models
{
    public class AlunoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        [Display(Name = "CPF")]
        public string Cpf { get; set; } = string.Empty;
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        [Display(Name = "CEP")]
        public string Cep { get; set; } = string.Empty;
        public string Rua { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        [Display(Name = "Número")]
        public short? Numero { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; } = string.Empty;
        [Display(Name = "Turma")]
        public int IdTurma { get; set; }
        public SelectList listaTurma { get; set; }
    }

    public class AlunoTelaIndex
    {
        public int IdAluno { get; set; }
        public int IdTurma { get; set; }
        public string NomeTurma { get; set; } = string.Empty;
        public List<Horarios> AlunosDisciplinas { get; set; }
        public List<AlunoAtividade> AlunosAtividade { get; set; }

    }

}
