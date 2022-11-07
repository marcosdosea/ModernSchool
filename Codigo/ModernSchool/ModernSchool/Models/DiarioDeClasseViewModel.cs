namespace ModernSchoolWEB.Models
{
    public class DiarioDeClasseViewModel
    {
      
        public int Id { get; set; }
      
        public int DataShow { get; set; }
        
        public int Livros { get; set; }

        public int LivrosSeduc { get; set; }

        public string? ResumoAula { get; set; }

        public int IdTurma { get; set; }

        public int IdComponente { get; set; }

        public int IdProfessor { get; set; }

        public string? TipoAula { get; set; }
    }
}
