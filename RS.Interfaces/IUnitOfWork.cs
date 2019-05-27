using System;
using System.Threading.Tasks;
using RS.Core;
using Type = RS.Core.Type;

namespace RS.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Category> CategoryRep { get; set; }
        IGenericRepository<Ingridient> IngridientRep { get; set; }
        IGenericRepository<IngridientForDish> IngridientForDishRep { get; set; }
        IGenericRepository<Recipe> RecipeRep { get; set; }
        IGenericRepository<TimePrepaering> TimePrepaeringRep { get; set; }
        IGenericRepository<Type> TypeRep { get; set; }
        Task SaveAsync();
    }
}
