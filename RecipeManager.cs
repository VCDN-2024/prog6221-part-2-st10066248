using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
 
    public class RecipeManager
    {
        private List<Recipe> recipes = new List<Recipe>();

        public event RecipeCaloriesExceededEventHandler RecipeCaloriesExceeded;

        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public void DisplayAllRecipes() // fucntion that deipslays all the recipes to user 
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
            Console.WriteLine("Recipes:");
            foreach (var recipe in sortedRecipes)
            {
                Console.WriteLine(recipe.Name);
            }
        }

        public Recipe GetRecipeByName(string name)
        {
            return recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void CheckRecipeCalories(Recipe recipe)
        {
            int totalCalories = recipe.CalculateTotalCalories();
            if (totalCalories > 300)
            {
                RecipeCaloriesExceeded?.Invoke(recipe.Name, totalCalories);
            }
        }
    }
}

