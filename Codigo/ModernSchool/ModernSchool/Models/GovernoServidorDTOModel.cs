using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class GovernoServidorDTOModel
    {
        [Key]
        public int IdPessoa { get; set; }
        public string? NomeCargo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string? Status { get; set; }
        public string? NomeGoverno { get; set; }
        public string? NomePessoa { get; set; }
    }
}
