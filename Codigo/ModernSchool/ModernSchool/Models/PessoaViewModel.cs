using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ModernSchoolWEB.Models
{
    public class PessoaViewModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public int Idade { get; set; }
        public string? Rua { get; set; }
        public string? Bairro { get; set; }
        public int Numero { get; set; }
        public DateTime? DataNascimento { get; set; }
       
    }
}
