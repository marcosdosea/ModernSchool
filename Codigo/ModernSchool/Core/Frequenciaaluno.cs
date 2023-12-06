using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Frequenciaaluno
    {
        public int IdDiarioDeClasse { get; set; }
        public int Faltas { get; set; }
        public int IdAluno { get; set; }

        public virtual Pessoa IdAlunoNavigation { get; set; }
        public virtual Diariodeclasse IdDiarioDeClasseNavigation { get; set; }
    }
}
