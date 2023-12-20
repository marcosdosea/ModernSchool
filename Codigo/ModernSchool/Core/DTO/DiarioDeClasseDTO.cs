using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class DiarioDeClasseDTO
    {
        public int Id { get; set; }
        public string Escola {  get; set; } = string.Empty;
        public string Turma {  get; set; } = string.Empty;
        public string Componente {  get; set; } = string.Empty;
    }
}
