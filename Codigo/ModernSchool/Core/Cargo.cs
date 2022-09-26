using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Cargo
    {
        public Cargo()
        {
            Governoservidors = new HashSet<Governoservidor>();
        }

        public int IdCargo { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Governoservidor> Governoservidors { get; set; }
    }
}
