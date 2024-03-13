using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class AlunoComponente
    {
        public string NomeComponente { get; set; } = string.Empty;
        public string Local { get; set; } = string.Empty;
        public string DiaSemana { get; set; } = string.Empty;
        public string HoraInicio { get; set; } = string.Empty;
        public string HoraFim { get; set; } = string.Empty;
        public Horarios HorarioComponente { get; set; }
        public int IdComponente { get; set; }
    }
    public class Horarios
    {
        public string NomeComponente { get; set; }
        public string Local { get; set; }
        public List<string> Horas { get; set; }
        public int IdComponente { get; set; }

    }

    public class AlunoAtividade
    {
        public DateTime Data { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Componente { get; set; } = string.Empty;
    }


}
