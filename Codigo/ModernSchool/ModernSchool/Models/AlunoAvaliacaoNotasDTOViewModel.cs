using Core.DTO;

namespace ModernSchoolWEB.Models
{
    public class AlunoAvaliacaoNotasDTOViewModel
    {
        public int Idavaliacao {  get; set; }
        public int IdTurma { get; set; }
        public int IdComponente {  get; set; }
        public List<AlunoAvaliacaoNotaDTO> ListaAluno {  get; set; }
    }
}
