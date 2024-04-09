using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Datatables
{
    public class DatatableRequest
    {
        public int Length { get; set; }
        public int Start { get; set; }
        public int Draw { get; set; }
        public Dictionary<string, string>? Search { get; set; }
        public List<Dictionary<string, string>>? Order { get; set; }
        public List<Dictionary<string, string>>? Columns { get; set; }
    }
}