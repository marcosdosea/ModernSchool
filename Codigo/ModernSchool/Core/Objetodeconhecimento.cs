using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Objetodeconhecimento
    {
        public Objetodeconhecimento()
        {
            Habilidades = new HashSet<Habilidade>();
            Objetodeconhecimentodiariodeclasses = new HashSet<Objetodeconhecimentodiariodeclasse>();
        }

        public int Id { get; set; }
        public int IdUnidadeTematica { get; set; }
        public string Descricao { get; set; }
        public int SequenciaProposta { get; set; }

        public virtual Unidadetematica IdUnidadeTematicaNavigation { get; set; }
        public virtual ICollection<Habilidade> Habilidades { get; set; }
        public virtual ICollection<Objetodeconhecimentodiariodeclasse> Objetodeconhecimentodiariodeclasses { get; set; }
    }
}
