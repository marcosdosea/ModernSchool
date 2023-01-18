using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class FrequenciaAlunoDTO
    {
        public int idAluno { get; set; }
        public int idDiarioDeClasse { get; set; }
        public int faltas { get; set; }
        public string? nomeAluno { get; set; }
        public string? turma { get; set; }
        public Boolean presente {get; set;}
        public string? componente  { get; set; }
    }
}
