using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class FrequenciaAlunoDTO
    {
        public int IdAluno { get; set; }
        public string? NomeAluno { get; set; }

        public int Faltas { get; set; } 
    }
}
