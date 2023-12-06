using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Anoletivo
    {
        public Anoletivo()
        {
            Periodos = new HashSet<Periodo>();
            Turmas = new HashSet<Turma>();
        }

        public int AnoLetivo1 { get; set; }
        public int IdEscola { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public virtual Escola IdEscolaNavigation { get; set; }
        public virtual ICollection<Periodo> Periodos { get; set; }
        public virtual ICollection<Turma> Turmas { get; set; }
    }
}
