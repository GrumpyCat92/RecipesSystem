namespace RS.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RS.DAL.RSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RS.DAL.RSContext context)
        {
            context.Categories.AddOrUpdate(
                new Category { Name = "Desert"});
            context.Categories.AddOrUpdate(
                new Category { Name = "Salad" });
            context.Categories.AddOrUpdate(
                new Category { Name = "Soup" });
            context.Categories.AddOrUpdate(
                new Category { Name = "Drink" });

            context.TimesPrepaering.AddOrUpdate(
                new TimePrepaering{ Period = "Less then 30 min"});
            context.TimesPrepaering.AddOrUpdate(
                new TimePrepaering { Period = "From 30 min to 60 min" });
            context.TimesPrepaering.AddOrUpdate(
                new TimePrepaering { Period = "More then 60 min" });

            context.Types.AddOrUpdate(
                new Core.Type {Name = "Breakfast"});
            context.Types.AddOrUpdate(
                new Core.Type { Name = "Dinner" });
            context.Types.AddOrUpdate(
                new Core.Type { Name = "Lunch" });
            context.Types.AddOrUpdate(
                new Core.Type { Name = "Celebration dish" });
        }
    }
}
