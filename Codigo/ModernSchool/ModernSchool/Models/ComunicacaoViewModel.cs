namespace ModernSchoolWEB.Models
{
    public class ComunicacaoViewModel
    {
        public int Id { get; set; }
        public byte EnviarAlunos { get; set; }
        public byte EnviarResponsaveis { get; set; }
        public string? Mensagem { get; set; }
        public int IdTurma { get; set; }
        public int IdComponente { get; set; }
    }
}
