using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Governoservidor
    {
        public int IdCargo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string Status { get; set; }
        public int IdGoverno { get; set; }
        public int IdPessoa { get; set; }

        public virtual Cargo IdCargoNavigation { get; set; }
        public virtual Governo IdGovernoNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
