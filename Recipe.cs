using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; } // where each ingredient is stored
        public List<RecipeStep> Steps { get; set; }  // where the steps for each recipe is stored

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<RecipeStep>();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }

        public void AddStep(RecipeStep step)
        {
            Steps.Add(step);
        }

        public void DisplayRecipe()
        {
            
            Console.WriteLine($"Recipe: {Name}");
            Console.ResetColor();
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine(ingredient);
            }
            Console.WriteLine("Steps:");
            int stepNumber = 1;
            foreach (var step in Steps)
            {
                Console.WriteLine($"{stepNumber}. {step}");
                stepNumber++;
            }
        }

        public int CalculateTotalCalories() // calculate the number of total calories 
        {
            return Ingredients.Sum(ingredient => ingredient.Calories);
        }
    }
}

