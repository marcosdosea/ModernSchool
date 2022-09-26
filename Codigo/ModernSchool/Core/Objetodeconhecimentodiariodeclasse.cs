using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Objetodeconhecimentodiariodeclasse
    {
        public int IdObjetoDeConhecimento { get; set; }
        public int IdDiarioDeClasse { get; set; }

        public virtual Diariodeclasse IdDiarioDeClasseNavigation { get; set; }
        public virtual Objetodeconhecimento IdObjetoDeConhecimentoNavigation { get; set; }
    }
}
