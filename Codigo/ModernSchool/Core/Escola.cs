using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Escola
    {
        public Escola()
        {
            Anoletivos = new HashSet<Anoletivo>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public short? Numero { get; set; }
        public int IdGoverno { get; set; }

        public virtual Governo IdGovernoNavigation { get; set; }
        public virtual ICollection<Anoletivo> Anoletivos { get; set; }
    }
}
