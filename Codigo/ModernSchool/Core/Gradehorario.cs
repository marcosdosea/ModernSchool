using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Gradehorario
    {
        public int Id { get; set; }
        public int IdComponente { get; set; }
        public int IdTurma { get; set; }
        public string DiaSemana { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public int IdProfessor { get; set; }

        public virtual Componente IdComponenteNavigation { get; set; }
        public virtual Pessoa IdProfessorNavigation { get; set; }
        public virtual Turma IdTurmaNavigation { get; set; }
    }
}
