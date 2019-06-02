using RS.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.BL.ViewModel
{
    public class RecipeList
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Core.Type Type { get; set; }
        public string TypeName { get; set; }
        public Category Category { get; set; }
        public string CategoryName { get; set; }
        public TimePrepaering TimePrepaering { get; set; }
        public string TimeString { get; set; }
        public List<Ingridients> IngridientsForDish { get; set; }
        public string Text { get; set; }
    }

    public class Ingridients
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Count { get; set; }
    }
}
