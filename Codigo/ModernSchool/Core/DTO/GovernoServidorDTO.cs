using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class GovernoServidorDTO
    {
        public int IdGoverno { get; set; }
        public string? NomeCargo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string? Status { get; set; }
        public string? NomeGoverno { get; set; }
        public string? NomePessoa { get; set; }
        
    }
}
