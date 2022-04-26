using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn.Entities
{
    public class Tool
    {
        [Key]
        public int TollId { get; set; }
        public string ToolName { get; set; }
        public string RecordNumber { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
