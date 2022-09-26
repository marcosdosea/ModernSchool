using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Avaliacao
    {
        public Avaliacao()
        {
            Alunoavaliacaos = new HashSet<Alunoavaliacao>();
        }

        public int Id { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime HorarioEntrega { get; set; }
        public string TipoDeAtividade { get; set; }
        public short? Peso { get; set; }
        public bool? Avaliativo { get; set; }
        public int IdTurma { get; set; }
        public int IdComponente { get; set; }
        public int IdPeriodo { get; set; }

        public virtual Componente IdComponenteNavigation { get; set; }
        public virtual Periodo IdPeriodoNavigation { get; set; }
        public virtual Turma IdTurmaNavigation { get; set; }
        public virtual ICollection<Alunoavaliacao> Alunoavaliacaos { get; set; }
    }
}
