using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Habilidade
    {
        public int IdHabilidade { get; set; }
        public string Descricao { get; set; }
        public int IdObjetoDeConhecimento { get; set; }

        public virtual Objetodeconhecimento IdObjetoDeConhecimentoNavigation { get; set; }
    }
}
