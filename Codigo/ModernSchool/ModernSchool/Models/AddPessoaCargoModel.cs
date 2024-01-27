using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Primitives;

namespace ModernSchoolWEB.Models
{
    public class AddPessoaCargoModel
    {
        public string Email {  get; set; } = string.Empty;
        public int IdCargo { get; set; }
        public int IdGoverno { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public DateTime DataDeNascimento { get; set; }

        public SelectList? ListCargo { get; set; }
        public  SelectList? ListaGoverno { get; set; }
    }
}
