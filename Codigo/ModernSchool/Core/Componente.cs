using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Componente
    {
        public Componente()
        {
            Avaliacaos = new HashSet<Avaliacao>();
            Comunicacaos = new HashSet<Comunicacao>();
            Diariodeclasses = new HashSet<Diariodeclasse>();
            Gradehorarios = new HashSet<Gradehorario>();
            Unidadetematicas = new HashSet<Unidadetematica>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Avaliacao> Avaliacaos { get; set; }
        public virtual ICollection<Comunicacao> Comunicacaos { get; set; }
        public virtual ICollection<Diariodeclasse> Diariodeclasses { get; set; }
        public virtual ICollection<Gradehorario> Gradehorarios { get; set; }
        public virtual ICollection<Unidadetematica> Unidadetematicas { get; set; }
    }
}
