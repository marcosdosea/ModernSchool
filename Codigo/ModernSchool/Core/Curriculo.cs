using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Curriculo
    {
        public Curriculo()
        {
            Unidadetematicas = new HashSet<Unidadetematica>();
        }

        public int Id { get; set; }
        public string Escolaridade { get; set; }
        public string AnoFaixa { get; set; }
        public short AnoLetivo1 { get; set; }
        public int IdGoverno { get; set; }

        public virtual Governo IdGovernoNavigation { get; set; }
        public virtual ICollection<Unidadetematica> Unidadetematicas { get; set; }
    }
}
