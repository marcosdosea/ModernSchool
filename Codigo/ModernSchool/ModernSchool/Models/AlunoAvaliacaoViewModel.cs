using Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ModernSchoolWEB.Models
{
    public class AlunoAvaliacaoViewModel
    {
        [Key]
        [Display(Name = "Id aluno")]
        public int IdAluno { get; set; }
        [Key]
        [Display(Name = "Id avaliacao")]
        public int IdAvaliacao { get; set; }
        [Display(Name = "Nota")]
        public decimal Nota { get; set; }
        [Display(Name = "Data de entrega")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataEntrega { get; set; }
        [Display(Name = "material de envio")]
        public byte[] Arquivo { get; set; }

        public SelectList? listaAluno { get; set; }

        public SelectList? listaAvaliacao { get; set; }
    }
}
