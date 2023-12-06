using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Alunocomunicacao
    {
        public int IdComunicacao { get; set; }
        public int IdAluno { get; set; }

        public virtual Pessoa IdAlunoNavigation { get; set; }
        public virtual Comunicacao IdComunicacaoNavigation { get; set; }
    }
}
