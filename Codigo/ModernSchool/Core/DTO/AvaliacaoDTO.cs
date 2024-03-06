using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class AvaliacaoDTO
    {
        public int Id { get; set; }
        public DateTime DataEntrega { get; set; }
        public string TipoAvaliacao { get; set; } =string.Empty;
        public short Peso { get; set; }
    }
}
