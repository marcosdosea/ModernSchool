using Core;
using Core.DTO;

namespace ModernSchoolWEB.Models
{
    public class AlunoAvaliacaoNotasDTOViewModel
    {
        public int Idavaliacao { get; set; }
        public int IdTurma { get; set; }
        public int IdComponente { get; set; }
        public string DescricaoAvaliacao { get; set; }
        public List<AlunoAvaliacaoNotaDTO> ListaAluno { get; set; }
    }

    public class NotasAlunoModel
    {
        public List<ComponenteNota> Componentes { get; set; }
        public List<PeriodoNota> PeriodosNotas { get; set; }
        public int IdTurma { get; set; }

    }

    public class PeriodoNota
    {
        public decimal Nota { get; set; }
        public string PeriodoAvaliacao { get; set; } = string.Empty;
        public int IdComponente { get; set; }

    }

    public class ComponenteNota
    {
        public int IdComponente { get; set; }
        public string NomeComponente { get; set; } = string.Empty;
    }
}
