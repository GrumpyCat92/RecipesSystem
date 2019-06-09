using System;
using System.Collections.Generic;
using System.Text;

namespace RS.BL.ViewModel
{
    public class CreateRecipe
    {
        public long CategoryId { get; set; }
        public long TimePrepaeringId { get; set; }
        public long TypeId { get; set; }
        public List<AddIngridients> IngridientsList { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        public CreateRecipe()
        {
            IngridientsList = new List<AddIngridients>();
        }
    }

    public class AddIngridients
    {
        public string Count { get; set; }
        public long Id { get; set; }
    }
}
