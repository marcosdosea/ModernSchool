using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class PessoaProfessorDTO
    {
        [Display(Name ="Codigo")]
        public int IdPessoa { get; set; }
        [Display(Name ="Nome")]
        public string NomePessoa { get; set; }
        [Display(Name="Cargo")]
        public string CargoPessoa { get; set; }
    }
}
