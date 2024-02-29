using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ModernSchoolWEB.Models
{
    public class FrequenciaAlunoDTOViewModel
    {
        public int IdAluno { get; set; }
        public string? NomeAluno { get; set; }
        public int Faltas { get; set; }
        public int IdDiario { get; set; }
    }
    public class FrequenciaListaAlunoDTOViewModel
    {
        public List<FrequenciaAlunoDTOViewModel> Lista { get; set; }
        public int IdTurma { get; set; }
        public int IdComponente { get; set; }
    }
}
