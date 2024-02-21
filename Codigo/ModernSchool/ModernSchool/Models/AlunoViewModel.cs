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
}
