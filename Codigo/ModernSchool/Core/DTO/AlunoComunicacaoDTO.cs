using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class AlunoComunicacaoDTO
    {
        public string Menssagem { get; set; } = string.Empty;
        public string NomeComponente {  get; set; } = string.Empty;
        public int IdComponente { get; set; }

        public int IdComunicado {  get; set; }

    }

    public class AlunoComunicacaoIndexDTO
    {
        public List<AlunoComunicacaoDTO> Comunicados { get; set; }
        public int IdTurma { get; set; }

        public string NomeTurma { get; set; } = string.Empty;
    }
}
