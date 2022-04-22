using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Magazyn.Entities
{
    public class Producent
    {
        public int ProducentId { get; set; }
        public string ProducentName { get; set; }

        public virtual ICollection<Tool> Tools { get; private set; }
            = new ObservableCollection<Tool>();
    }
}