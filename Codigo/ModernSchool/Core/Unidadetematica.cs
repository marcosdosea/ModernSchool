using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Unidadetematica
    {
        public Unidadetematica()
        {
            Objetodeconhecimentos = new HashSet<Objetodeconhecimento>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public short? AnoLetivo1 { get; set; }
        public int IdCurriculo { get; set; }
        public int IdComponente { get; set; }

        public virtual Componente IdComponenteNavigation { get; set; }
        public virtual Curriculo IdCurriculoNavigation { get; set; }
        public virtual ICollection<Objetodeconhecimento> Objetodeconhecimentos { get; set; }
    }
}
