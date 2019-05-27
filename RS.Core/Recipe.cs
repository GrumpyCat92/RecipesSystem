using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Core
{
    public class Recipe
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        public Category Category { get; set; }
        public TimePrepaering TimePrepaering { get; set; }
        public ICollection<IngridientForDish> IngridientsForDish { get; set; }
        public string Text { get; set; }

        public Recipe()
        {
            IngridientsForDish = new List<IngridientForDish>();
        }
    }
}
