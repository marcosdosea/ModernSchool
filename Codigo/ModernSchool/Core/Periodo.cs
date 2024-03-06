using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Periodo
    {
        public Periodo()
        {
            Avaliacaos = new HashSet<Avaliacao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int AnoLetivo1 { get; set; }

        public virtual Anoletivo AnoLetivoNavigation { get; set; }
        public virtual ICollection<Avaliacao> Avaliacaos { get; set; }
    }
}
