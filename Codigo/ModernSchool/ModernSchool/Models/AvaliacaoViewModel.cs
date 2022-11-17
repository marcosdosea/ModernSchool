using Microsoft.AspNetCore.Mvc.Rendering;

namespace ModernSchoolWEB.Models
{
    public class AvaliacaoViewModel
    {

        public int Id { get; set; }
        public DateTime DataEntrega{ get; set; }
        public DateTime HorarioEntrega{ get; set; }
        public string? TipoDeAtividade { get; set; }
        public int Peso { get; set; }
        public int Avaliativo { get; set; }
        public int IdTurma { get; set; }
        public int IdComponente { get; set; }
        public int IdPeriodo { get; set;}
        public SelectList? ListaComponentes { get; set; }
    }
}
