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
        
        public int IdPessoa { get; set; }
        
        public string NomePessoa { get; set; }
      
        public string CargoPessoa { get; set; }
    }
}
