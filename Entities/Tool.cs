using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn.Entities
{
    public class Tool
    {
        public int TollId { get; set; }
        public string ToolName { get; set; }
        public string RecordNumber { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int ProducentId { get; set; }
        public virtual Producent Producent {get; set;}


    }
}
