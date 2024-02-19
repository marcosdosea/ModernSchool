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
            Governoservidors = new HashSet<Governoservidor>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public short? Numero { get; set; }
        public int IdGoverno { get; set; }
        public int IdDiretor { get; set; }

        public virtual Pessoa IdDiretorNavigation { get; set; }
        public virtual Governo IdGovernoNavigation { get; set; }
        public virtual ICollection<Anoletivo> Anoletivos { get; set; }
        public virtual ICollection<Governoservidor> Governoservidors { get; set; }
    }
}
