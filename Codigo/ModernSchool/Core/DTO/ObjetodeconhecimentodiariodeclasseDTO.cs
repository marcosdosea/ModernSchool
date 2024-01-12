using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class ObjetodeconhecimentodiariodeclasseDTO
    {
        public string UnidadeTematica { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;

        public int IdObjeto { get; set; }
        public int IdDiarioClasse {  get; set; }
    }
}
