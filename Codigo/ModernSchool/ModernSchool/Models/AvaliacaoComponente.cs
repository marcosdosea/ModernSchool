using Core.DTO;
using System.Drawing;

namespace ModernSchoolWEB.Models
{
    public class AvaliacaoComponente
    {
        public List<DiarioAluno> DiarioAlunos { get; set; } 
        public int IdComponente { get; set; }
        public string NomeComponente { get; set; } = string.Empty;
        public int IdTurma { get; set; }
    }
}
