using RS.BL.ViewModel;
using RS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ResultMessage CreateRecipe(CreateRecipe recipe)
        {
            try
            {
                var category = Database.CategoryRep.Get(recipe.CategoryId);
                if (category == null)
                    return new ResultMessage("Category is not exist");
                var timePrep = Database.TimePrepaeringRep.Get(recipe.TimePrepaeringId);
                if (timePrep == null)
                    return new ResultMessage("Time prepaering is not exist");
                var type = Database.TypeRep.Get(recipe.TypeId);
                if (type == null)
                    return new ResultMessage("Type is not exist");

                Database.RecipeRep.Create(new Core.Recipe
                {
                    Name = recipe.Name,
                    Text = recipe.Text,
                    Category = category,
                    Type = type,
                    TimePrepaering = timePrep
                });

                Database.RecipeRep.Save();

                var receipeBase = Database.RecipeRep.GetList()
                    .Where(e => e.Name == recipe.Name)
                    .FirstOrDefault();

                foreach (var item in recipe.IngridientsList)
                {
                    var ingridient = Database.IngridientRep.Get(item.Id);
                    if (ingridient == null)
                        return new ResultMessage("Ingridient is not exist");
                    Database.IngridientForDishRep.Create(new Core.IngridientForDish
                    {
                        Count = item.Count,
                        Recipe = receipeBase,
                        Ingridient = ingridient
                    });

                    Database.IngridientForDishRep.Save();
                }

                return new ResultMessage(false, "Success");
            }
            catch(Exception ex)
            {
                return new ResultMessage(ex.Message);
            }
        }
    }
}
