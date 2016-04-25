using Receptbok.Models;
using System.Data.Entity;

namespace Receptbok.DAL
{
    public class ReceptbokInitializer : CreateDatabaseIfNotExists<ReceptbokContext>
    {
        protected override void Seed(ReceptbokContext context)
        {
            context.Categories.Add(new Categories { CategoryId = 1, CategoryName = "Tårtor" });
            context.Categories.Add(new Categories { CategoryId = 2, CategoryName = "Semlor" });
            context.Categories.Add(new Categories { CategoryId = 3, CategoryName = "Bullar" });

            context.Recipes.Add(new Recipes { RecipeId = 1, RecipeName = "Prinsesstårta", RecipeInstructions = "1st prinsessa", CategoryId = 1 });
            context.Recipes.Add(new Recipes { RecipeId = 2, RecipeName = "Chokladtårta", RecipeInstructions = "1kg choklad", CategoryId = 1 });
            
            context.Recipes.Add(new Recipes { RecipeId = 3, RecipeName = "Ostsemla", RecipeInstructions = "1kg ost", CategoryId = 2 });
            context.Recipes.Add(new Recipes { RecipeId = 4, RecipeName = "Morotssemla", RecipeInstructions = "1kg morötter", CategoryId = 2 });

            context.Recipes.Add(new Recipes { RecipeId = 5, RecipeName = "Lussebullar", RecipeInstructions = "1st Lucia", CategoryId = 3 });
            context.Recipes.Add(new Recipes { RecipeId = 6, RecipeName = "Kaffebullar", RecipeInstructions = "1kg kaffe", CategoryId = 3 });

            base.Seed(context);
        }
    }
}