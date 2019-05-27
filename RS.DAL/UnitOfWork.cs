using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RS.Core;
using RS.Interfaces;

namespace RS.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public RSContext db;

        private IGenericRepository<Category> categoryRep;
        private IGenericRepository<Ingridient> ingridientRep;
        private IGenericRepository<IngridientForDish> ingridientForDishRep;
        private IGenericRepository<Recipe> recipeRep;
        private IGenericRepository<TimePrepaering> timePrepaeringRep;
        private IGenericRepository<Core.Type> typeRep;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
