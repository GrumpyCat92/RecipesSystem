using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Core
{
    public class TimePrepaering
    {
        public long Id { get; set; }
        public string Period { get; set; }

        public ICollection<Recipe> Recipes { get; set; }

        public TimePrepaering()
        {
            Recipes = new List<Recipe>();
        }
    }
}
