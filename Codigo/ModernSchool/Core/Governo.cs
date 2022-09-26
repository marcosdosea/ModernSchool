using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Governo
    {
        public Governo()
        {
            Curriculos = new HashSet<Curriculo>();
            Escolas = new HashSet<Escola>();
            Governoservidors = new HashSet<Governoservidor>();
        }

        public int Id { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string DependenciaAdministrativa { get; set; }

        public virtual ICollection<Curriculo> Curriculos { get; set; }
        public virtual ICollection<Escola> Escolas { get; set; }
        public virtual ICollection<Governoservidor> Governoservidors { get; set; }
    }
}
