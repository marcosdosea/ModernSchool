using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Frequenciaaluno
    {
        public int IdPessoa { get; set; }
        public int IdDiarioDeClasse { get; set; }
        public int Faltas { get; set; }

        public virtual Diariodeclasse IdDiarioDeClasseNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
