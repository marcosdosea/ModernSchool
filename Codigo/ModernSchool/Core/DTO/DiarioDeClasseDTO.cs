using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class DiarioDeClasseDTO
    {
        public int Id { get; set; }
        public string Escola {  get; set; } = string.Empty;
        public string Turma {  get; set; } = string.Empty;
        public string Componente {  get; set; } = string.Empty;
    }

    public class DiarioClasseHabilidade
    {
        public string UnidadeTematica { get; set; } = string.Empty;
        public string Data { get; set;} = string.Empty;
        public string ObjetoConhecimento {  get; set; } = string.Empty;
        public string Habilidade {  get; set; } = string.Empty;
        public bool Selecionado { get; set; } = false;
        public int IdObjeto { get; set; }
    }

}
