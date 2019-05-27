using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Core
{
    public class Ingridient
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<IngridientForDish> IngridientsDish { get; set; }

        public Ingridient()
        {
            IngridientsDish = new List<IngridientForDish>();
        }
    }
}
