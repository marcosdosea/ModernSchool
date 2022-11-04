using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class GradeHorarioDTO
    {
        public int Id { get; set; }
        public string? Componente { get; set; }
        public string? Dia { get; set; }
        public string? HoraInicio { get; set; }
        public string? HoraFim { get; set; }
        public string? Professor { get; set; }
    }
}
