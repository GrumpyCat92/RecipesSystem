using System;
using System.Threading.Tasks;
using RS.Core;
using Type = RS.Core.Type;

namespace RS.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Category> CategoryRep { get; }
        IGenericRepository<Ingridient> IngridientRep { get; }
        IGenericRepository<IngridientForDish> IngridientForDishRep { get;}
        IGenericRepository<Recipe> RecipeRep { get; }
        IGenericRepository<TimePrepaering> TimePrepaeringRep { get;}
        IGenericRepository<Type> TypeRep { get; }
        Task SaveAsync();
    }
}
