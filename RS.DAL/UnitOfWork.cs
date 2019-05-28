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

        public UnitOfWork()
        {
            db = new RSContext();
            categoryRep = new Repository<Category>(db);
            ingridientRep = new Repository<Ingridient>(db);
            ingridientForDishRep = new Repository<IngridientForDish>(db);
            recipeRep = new Repository<Recipe>(db);
            timePrepaeringRep = new Repository<TimePrepaering>(db);
            typeRep = new Repository<Core.Type>(db);
        }
        
        public IGenericRepository<Category> CategoryRep => categoryRep;
        
        public IGenericRepository<Ingridient> IngridientRep => ingridientRep;
        
        public IGenericRepository<IngridientForDish> IngridientForDishRep => ingridientForDishRep;
        
        public IGenericRepository<Recipe> RecipeRep => recipeRep;
        
        public IGenericRepository<TimePrepaering> TimePrepaeringRep => timePrepaeringRep;
        
        public IGenericRepository<RS.Core.Type> TypeRep => typeRep;
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    categoryRep.Dispose();
                    ingridientRep.Dispose();
                    ingridientForDishRep.Dispose();
                    recipeRep.Dispose();
                    timePrepaeringRep.Dispose();
                    typeRep.Dispose();
                }
                this.disposed = true;
            }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
