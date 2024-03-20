﻿using Core.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace ModernSchoolWEB.Models
{
    public class AlunoTurmaViewModel
    {
        public int Id { get; set; }
        [Display(Prompt = "Ex: Nome do Aluno")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo CPF é Obrigatório")]
        [Display(Name = "CPF", Prompt = "Ex: 000.000.000-00")]
        public string Cpf { get; set; } = string.Empty;
        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Campo Data de Nascimento é Obrigatório")]
        public DateTime DataNascimento { get; set; }
        [Display(Name = "CEP", Prompt = "Ex: 00000-000")]
        [Required(ErrorMessage = "Campo CEP é Obrigatório")]
        public string Cep { get; set; } = string.Empty;
        [Display(Prompt = "Ex: Nome da Rua")]
        public string Rua { get; set; } = string.Empty;
        [Display(Prompt = "Ex: Nome do Bairro")]
        public string Bairro { get; set; } = string.Empty;
        [Display(Name = "Número", Prompt = "Ex: 60")]
        public short? Numero { get; set; }
        [Display(Name = "E-mail", Prompt = "Ex: email@xemplo.com")]
        [Required(ErrorMessage = "Campo E-mail é Obrigatório")]
        public string Email { get; set; } = string.Empty;
        [Display(Name = "Turma")]
        public int IdTurma { get; set; }
        public string Turma { get; set; } = string.Empty;
        public string Sala { get; set; } = string.Empty;
        public string NomeEscola { get; set; } = string.Empty;  
        public int NumVagas { get; set; }
        public List<IndexAlunoTurmaDTO> Alunos { get; set; }
    }


    public class AlunoTelaIndex
    {
        public int IdAluno { get; set; }
        public int IdTurma { get; set; }
        public string NomeTurma { get; set; } = string.Empty;
        public List<Horarios> AlunosDisciplinas { get; set; }
        public List<AlunoAtividadeDTO> AlunosAtividade { get; set; }

    }

}