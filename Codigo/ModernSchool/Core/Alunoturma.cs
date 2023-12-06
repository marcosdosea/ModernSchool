using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Alunoturma
    {
        public int IdTurma { get; set; }
        public int IdAluno { get; set; }

        public virtual Pessoa IdAlunoNavigation { get; set; }
        public virtual Turma IdTurmaNavigation { get; set; }
    }
}
