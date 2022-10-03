namespace ModernSchoolWEB.Models
{
    public class TurmaViewModel
    {
        public int Id { get; set; }
        public int AnoLetivo { get; set; }
        public string? Turma1 { get; set; }
        public int Vagas { get; set; }
        public int VagasDisponiveis { get; set; }
        public string? Sala { get; set; }
        public string? Escolaridade { get; set; }
        public string? Status { get; set; }
    }
}
