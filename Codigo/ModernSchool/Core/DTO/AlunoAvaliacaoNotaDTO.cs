using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class AlunoAvaliacaoNotaDTO
    {
        public int IdAluno { get; set; }
        public string NomeAluno { get; set; } = string.Empty;
        public decimal Notas { get; set; }
    }
}
