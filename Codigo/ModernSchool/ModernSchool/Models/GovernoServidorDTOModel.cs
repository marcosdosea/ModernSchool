using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class GovernoServidorDTOModel
    {
        
        public int IdPessoa { get; set; }
        
        public int IdGoverno { get; set; }

        public string? NomeCargo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string? Status { get; set; }
        public string? NomeGoverno { get; set; }
        public string? NomePessoa { get; set; }
    }
}
