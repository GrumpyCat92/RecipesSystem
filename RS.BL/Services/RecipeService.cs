using RS.BL.ViewModel;
using RS.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.BL.Services
{
    public class RecipeService
    {
        IUnitOfWork Database { get; set; }

        public RecipeService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IList<RecipeList> GetAllRecipes()
        {
            List<RecipeList> recipes = new List<RecipeList>();
            foreach(var item in Database.RecipeRep.GetList())
            {
                var recipe = new RecipeList
                {
                    Id = item.Id,
                    Category = item.Category,
                    CategoryName = item.Category.Name,
                    Type = item.Type,
                    TypeName = item.Type.Name,
                    TimePrepaering = item.TimePrepaering,
                    TimeString = item.TimePrepaering.Period,
                    Name = item.Name,
                    Text = item.Text
                };

                var ingridients = new List<Ingridients>();
                foreach(var subitem in item.IngridientsForDish)
                {
                    ingridients.Add(new Ingridients
                    {
                        Count = subitem.Count,
                        Id = subitem.Id,
                        Name = subitem.Ingridient.Name
                    });
                }

                recipe.IngridientsForDish = ingridients;
            }

            return recipes;
        }
    }
}
