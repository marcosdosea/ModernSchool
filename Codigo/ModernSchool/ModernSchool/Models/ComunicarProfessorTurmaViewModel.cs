using Core.DTO;
using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class ComunicarProfessorTurmaViewModel
    {
        public List<IndexAlunoTurmaDTO> Alunos { get; set; }
        public byte EnviarAlunos { get; set; }
        public int IdTurma { get; set; }
        public int IdComponente {  get; set; }
        public string Turma { get; set; } = string.Empty;
        public string Componente { get; set; } = string.Empty;
        [Display(Name = "Mensagem", Prompt = "Digite Algo...")]
        [Required(ErrorMessage = "Campo mensagem é obrigatório")]
        [StringLength(500, ErrorMessage = "A Mensagem deve ter no máximo 500 caracteres")]
        public string Menssagem { get; set; } = string.Empty;
    }
}
