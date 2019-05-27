using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Core
{
    public class IngridientForDish
    {
        public long Id { get; set; }
        public Ingridient Ingridient { get; set; }
        public string Count { get; set; }
        public Recipe Recipe { get; set; }

    }
}
