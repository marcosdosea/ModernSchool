using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Alunoavaliacaos = new HashSet<Alunoavaliacao>();
            Alunocomunicacaos = new HashSet<Alunocomunicacao>();
            Alunoturmas = new HashSet<Alunoturma>();
            Comunicacaos = new HashSet<Comunicacao>();
            Diariodeclasses = new HashSet<Diariodeclasse>();
            Escolas = new HashSet<Escola>();
            Frequenciaalunos = new HashSet<Frequenciaaluno>();
            Governoservidors = new HashSet<Governoservidor>();
            Gradehorarios = new HashSet<Gradehorario>();
            Pessoacomunicacaos = new HashSet<Pessoacomunicacao>();
        }

        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public short? Numero { get; set; }
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Alunoavaliacao> Alunoavaliacaos { get; set; }
        public virtual ICollection<Alunocomunicacao> Alunocomunicacaos { get; set; }
        public virtual ICollection<Alunoturma> Alunoturmas { get; set; }
        public virtual ICollection<Comunicacao> Comunicacaos { get; set; }
        public virtual ICollection<Diariodeclasse> Diariodeclasses { get; set; }
        public virtual ICollection<Escola> Escolas { get; set; }
        public virtual ICollection<Frequenciaaluno> Frequenciaalunos { get; set; }
        public virtual ICollection<Governoservidor> Governoservidors { get; set; }
        public virtual ICollection<Gradehorario> Gradehorarios { get; set; }
        public virtual ICollection<Pessoacomunicacao> Pessoacomunicacaos { get; set; }
    }
}
