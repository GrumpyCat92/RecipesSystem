using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RS.Core;

namespace RS.DAL
{
    public class RSContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingridient> Ingridients { get; set; }
        public DbSet<IngridientForDish> IngridientsForDish { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RS.Core.Type> Types { get; set; }
        public DbSet<TimePrepaering> TimesPrepaering { get; set; }
    }
}
