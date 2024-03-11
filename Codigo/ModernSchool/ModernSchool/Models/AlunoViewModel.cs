using Core.DTO;
namespace ModernSchoolWEB.Models
{
    public class AlunoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Cep { get; set; } = string.Empty;
        public string Rua { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public short? Numero { get; set; }
        public string Email { get; set; } = string.Empty;

        public int IdTurma { get; set; }
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
