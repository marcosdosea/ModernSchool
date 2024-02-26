using Core.DTO;

namespace ModernSchoolWEB.Models
{
    public class DiarioClasseProfessorDTO
    {
        public IEnumerable<ObjetodeconhecimentodiariodeclasseDTO> ObjetoConhecimento { get; set; }
        public int IdComponente {  get; set; }
        public int IdProfessor { get; set; }
        public int IdTurma {  get; set; }

        public string NomeTurma {  get; set; } = string.Empty;
        public string NomeComponente { get; set; } = string.Empty;
    }
}
