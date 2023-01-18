using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class AlunoAvaliacaoDTO
    {
        public int IdAluno { get; set; }
        public int IdAvaliacao { get; set; }
        public decimal Nota { get; set; }
        public DateTime DataEntrega { get; set; }
        public byte[] Arquivo { get; set; }
        public string NomeAluno { get; set; }
        public string NomeTurma { get; set; }
        public bool isAvaliativo { get; set; }
    }
}
