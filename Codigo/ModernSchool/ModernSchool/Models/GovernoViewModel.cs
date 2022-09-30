using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class GovernoViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Municipio { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string DependenciaAdministrativa { get; set; }
    }
}
