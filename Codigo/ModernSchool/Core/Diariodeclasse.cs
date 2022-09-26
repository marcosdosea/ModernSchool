using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Diariodeclasse
    {
        public Diariodeclasse()
        {
            Frequenciaalunos = new HashSet<Frequenciaaluno>();
            Objetodeconhecimentodiariodeclasses = new HashSet<Objetodeconhecimentodiariodeclasse>();
        }

        public int Id { get; set; }
        public bool? DataShow { get; set; }
        public bool? Livros { get; set; }
        public bool? LivrosSeduc { get; set; }
        public string ResumoAula { get; set; }
        public int IdTurma { get; set; }
        public int IdComponente { get; set; }
        public int IdProfessor { get; set; }
        public string TipoAula { get; set; }

        public virtual Componente IdComponenteNavigation { get; set; }
        public virtual Pessoa IdProfessorNavigation { get; set; }
        public virtual Turma IdTurmaNavigation { get; set; }
        public virtual ICollection<Frequenciaaluno> Frequenciaalunos { get; set; }
        public virtual ICollection<Objetodeconhecimentodiariodeclasse> Objetodeconhecimentodiariodeclasses { get; set; }
    }
}
