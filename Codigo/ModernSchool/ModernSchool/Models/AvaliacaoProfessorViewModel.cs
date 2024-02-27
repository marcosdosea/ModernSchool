using Core.DTO;

namespace ModernSchoolWEB.Models
{
    public class AvaliacaoProfessorViewModel
    {
        public List<AvaliacaoDTO> Avalicoes { get; set; }
        public int IdTurma {  get; set; }
        public int IdComponente { get; set; }


    }
}
