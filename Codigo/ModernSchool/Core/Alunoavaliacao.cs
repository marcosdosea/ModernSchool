using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Alunoavaliacao
    {
        public int IdPessoa { get; set; }
        public int IdAvaliacao { get; set; }
        public decimal Nota { get; set; }
        public DateTime DataEntrega { get; set; }
        public byte[] Arquivo { get; set; }

        public virtual Avaliacao IdAvaliacaoNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
