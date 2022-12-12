using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class GovernoServidorDTOModel
    {
        
        public int IdPessoa { get; set; }
        
        public int IdGoverno { get; set; }

        [Display (Name ="Cargo")]
        public string? NomeCargo { get; set; }
        public string? Status { get; set; }
        [Display (Name = "Governo")]
        public string? NomeGoverno { get; set; }
        [Display (Name ="Pessoa")]
        public string? NomePessoa { get; set; }
    }
}
