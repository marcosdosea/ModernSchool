using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Alunocomunicacao
    {
        public int IdPessoa { get; set; }
        public int IdComunicacao { get; set; }

        public virtual Comunicacao IdComunicacaoNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
