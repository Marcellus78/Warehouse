using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Magazyn.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Tool> Tools { get; private set; } = new ObservableCollection<Tool>();
    }
}