using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RS.Core
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Recipe> Recipes { get; set; }

        public Category()
        {
            Recipes = new List<Recipe>();
        }
    }
}
