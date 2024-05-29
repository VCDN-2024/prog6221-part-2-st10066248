using System;

namespace RecipeApp
{
    // Delegate for notifying when recipe calories exceed 300
    public delegate void RecipeCaloriesExceededEventHandler(string recipeName, int totalCalories);

    class Program
    {
        static void Main(string[] args)
        {
            RecipeManager recipeManager = new RecipeManager();
            Console.ForegroundColor
          = ConsoleColor.Blue;

            // Subscribe to the RecipeCaloriesExceeded event
            recipeManager.RecipeCaloriesExceeded += NotifyCaloriesExceeded;

            while (true)
            {
                try
                {
                    Console.WriteLine("\nSelect an option:");
                    Console.WriteLine("1. Add Recipe");
                    Console.WriteLine("2. Display All Recipes");
                    Console.WriteLine("3. View Recipe Details");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddRecipe(recipeManager);
                            break;
                        case 2:
                            recipeManager.DisplayAllRecipes();
                            break;
                        case 3:
                            ViewRecipe(recipeManager);
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid input format. Please enter the correct information.");
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error occurred.");
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        
        /// Adds a new recipe to the RecipeManager.
        
        /// <param name="recipeManager">The RecipeManager instance.</param>
        static void AddRecipe(RecipeManager recipeManager)
        {
            try
            {
                Console.Write("Enter recipe name: ");
                string name = Console.ReadLine();
                Recipe recipe = new Recipe(name);

                Console.WriteLine("\nEnter the details for the recipe:");
                Console.Write("Number of ingredients: ");
                int numOfIngredients = int.Parse(Console.ReadLine());

                for (int i = 0; i < numOfIngredients; i++) // loop executes for each of the 
                {
                    Console.Write("Ingredient name: ");
                    string ingredientName = Console.ReadLine();
                    Console.Write("Quantity: ");
                    double quantity = double.Parse(Console.ReadLine());
                    Console.Write("Unit: ");
                    string unit = Console.ReadLine();
                    Console.Write("Calories: ");
                    int calories = int.Parse(Console.ReadLine());
                    Console.Write("Food Group: ");
                    string foodGroup = Console.ReadLine();
                    recipe.AddIngredient(new Ingredient(ingredientName, quantity, unit, calories, foodGroup));
                }

                Console.Write("Number of steps: ");
                int numOfSteps = int.Parse(Console.ReadLine());

                for (int i = 0; i < numOfSteps; i++)
                {
                    Console.Write($"Step {i + 1}: ");
                    string description = Console.ReadLine();
                    recipe.AddStep(new RecipeStep(description));
                }

                recipeManager.AddRecipe(recipe);
                recipeManager.CheckRecipeCalories(recipe);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please enter the correct information.");
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

       
        static void ViewRecipe(RecipeManager recipeManager)
        {
            try
            {
                Console.Write("Enter recipe name: ");
                string name = Console.ReadLine();
                Recipe recipe = recipeManager.GetRecipeByName(name);
                if (recipe != null)
                {
                    recipe.DisplayRecipe();
                }
                else
                {
                    Console.WriteLine("Recipe not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

       
        static void NotifyCaloriesExceeded(string recipeName, int totalCalories)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Warning: The recipe '{recipeName}' exceeds 300 calories with a total of {totalCalories} calories.");
            Console.ResetColor();
        }
    }
}
