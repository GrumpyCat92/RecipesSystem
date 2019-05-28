using Ninject.Modules;
using RS.Core;
using RS.DAL;
using RS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipesSystem.Utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IGenericRepository<Category>>().To<Repository<Category>>();
            Bind<IGenericRepository<Ingridient>>().To<Repository<Ingridient>>();
            Bind<IGenericRepository<IngridientForDish>>().To<Repository<IngridientForDish>>();
            Bind<IGenericRepository<Recipe>>().To<Repository<Recipe>>();
            Bind<IGenericRepository<TimePrepaering>>().To<Repository<TimePrepaering>>();
            Bind<IGenericRepository<RS.Core.Type>>().To<Repository<RS.Core.Type>>();
        }
    }
}