using Microsoft.AspNetCore.Mvc.Rendering;

namespace ModernSchoolWEB.Models
{
    public class AlunoTurmaViewModel
    {
        public int IdAluno { get; set; }

        public int IdTurma { get; set; }

        public SelectList? listaAluno { get; set; }  

    }
}
