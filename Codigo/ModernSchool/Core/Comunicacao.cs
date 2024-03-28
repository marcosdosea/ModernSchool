using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Comunicacao
    {
        public Comunicacao()
        {
            Alunocomunicacaos = new HashSet<Alunocomunicacao>();
            Pessoacomunicacaos = new HashSet<Pessoacomunicacao>();
        }

        public int Id { get; set; }
        public DateTime Data { get; set; }
        public byte EnviarAlunos { get; set; }
        public byte EnviarResponsaveis { get; set; }
        public string Mensagem { get; set; }
        public int IdPessoaRemetente { get; set; }
        public int IdTurma { get; set; }
        public int IdComponente { get; set; }

        public virtual Componente IdComponenteNavigation { get; set; }
        public virtual Pessoa IdPessoaRemetenteNavigation { get; set; }
        public virtual Turma IdTurmaNavigation { get; set; }
        public virtual ICollection<Alunocomunicacao> Alunocomunicacaos { get; set; }
        public virtual ICollection<Pessoacomunicacao> Pessoacomunicacaos { get; set; }
    }
}
