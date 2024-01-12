using Core;
using Core.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ModernSchoolWEB.Models
{
    public class DiarioDeClasseViewModel
    {
        
        public int Id { get; set; }
        [Display(Name ="Data Show")]
        public bool? DataShow { get; set; }
        [Display(Name ="Livos")]
        public bool? Livros { get; set; }
        [Display(Name = "Livros Seduc")]
        public bool? LivrosSeduc { get; set; }
        [Display(Name = "Resumo da aula")]
        public string? ResumoAula { get; set; }
        [Display(Name ="Turma")]
        public int IdTurma { get; set; }
        [Display(Name ="Componente")]
        public int IdComponente { get; set; }
        [Display(Name ="Professor")]
        public int IdProfessor { get; set; }
        [Display(Name ="Tipo de aula")]
        public string? TipoAula { get; set; }

        public SelectList? listaTurma { get; set; }

        public SelectList? listaProfessor { get; set; }

        public SelectList? listaComponente { get; set; }
        public List<DiarioClasseHabilidade> Habilidade { get; set;}
    }



}