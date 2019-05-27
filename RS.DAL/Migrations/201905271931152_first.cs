namespace RS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Text = c.String(),
                        Category_Id = c.Long(),
                        TimePrepaering_Id = c.Long(),
                        Type_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.TimePrepaerings", t => t.TimePrepaering_Id)
                .ForeignKey("dbo.Types", t => t.Type_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.TimePrepaering_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.IngridientForDishes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Count = c.String(),
                        Ingridient_Id = c.Long(),
                        Recipe_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingridients", t => t.Ingridient_Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.Ingridient_Id)
                .Index(t => t.Recipe_Id);
            
            CreateTable(
                "dbo.Ingridients",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TimePrepaerings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Period = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "Type_Id", "dbo.Types");
            DropForeignKey("dbo.Recipes", "TimePrepaering_Id", "dbo.TimePrepaerings");
            DropForeignKey("dbo.IngridientForDishes", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.IngridientForDishes", "Ingridient_Id", "dbo.Ingridients");
            DropForeignKey("dbo.Recipes", "Category_Id", "dbo.Categories");
            DropIndex("dbo.IngridientForDishes", new[] { "Recipe_Id" });
            DropIndex("dbo.IngridientForDishes", new[] { "Ingridient_Id" });
            DropIndex("dbo.Recipes", new[] { "Type_Id" });
            DropIndex("dbo.Recipes", new[] { "TimePrepaering_Id" });
            DropIndex("dbo.Recipes", new[] { "Category_Id" });
            DropTable("dbo.Types");
            DropTable("dbo.TimePrepaerings");
            DropTable("dbo.Ingridients");
            DropTable("dbo.IngridientForDishes");
            DropTable("dbo.Recipes");
            DropTable("dbo.Categories");
        }
    }
}
