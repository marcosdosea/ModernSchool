using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Turma
    {
        public Turma()
        {
            Alunoturmas = new HashSet<Alunoturma>();
            Avaliacaos = new HashSet<Avaliacao>();
            Comunicacaos = new HashSet<Comunicacao>();
            Diariodeclasses = new HashSet<Diariodeclasse>();
            Gradehorarios = new HashSet<Gradehorario>();
        }

        public int Id { get; set; }
        public int AnoLetivo1 { get; set; }
        public string Turma1 { get; set; }
        public int Vagas { get; set; }
        public int VagasDisponiveis { get; set; }
        public string Sala { get; set; }
        public string Escolaridade { get; set; }
        public string Status { get; set; }

        public virtual Anoletivo AnoLetivoNavigation { get; set; }
        public virtual ICollection<Alunoturma> Alunoturmas { get; set; }
        public virtual ICollection<Avaliacao> Avaliacaos { get; set; }
        public virtual ICollection<Comunicacao> Comunicacaos { get; set; }
        public virtual ICollection<Diariodeclasse> Diariodeclasses { get; set; }
        public virtual ICollection<Gradehorario> Gradehorarios { get; set; }
    }
}
