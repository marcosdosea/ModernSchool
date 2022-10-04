namespace ModernSchoolWEB.Models
{
    public class PeriodoViewModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int AnoLetivo { get; set; }
    }
}
