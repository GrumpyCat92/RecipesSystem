using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Core
{
    public class Type
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Recipe> Recipes { get; set; }

        public Type()
        {
            Recipes = new List<Recipe>();
        }
    }
}
