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

        public string? NomePessoa { get; set; }

        public string? CargoPessoa { get; set; }

        public string? CPF { get; set; }

        public short? Idade { get; set; }

        public string? Rua { get; set; }

        public string? Bairro { get; set; }

        public short? Numero { get; set; }
        public DateTime? DataNascimento { get; set; }

    }
}
