using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecipeApp.Tests
{
    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        public void TestTotalCalories()
        {
            // Arrange
            Recipe recipe = new Recipe("Test Recipe");
            recipe.AddIngredient(new Ingredient("Sugar", 1, "cup", 774, "Carbohydrates"));
            recipe.AddIngredient(new Ingredient("Butter", 0.5, "cup", 814, "Fats"));  

            // Act
            int totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(1588, totalCalories);// tests if the calories are properly calculated 
        }

        [TestMethod]
        public void TestCaloriesExceedNotification()
        {
            // Arrange
            RecipeManager manager = new RecipeManager();
            bool eventFired = false;
            manager.RecipeCaloriesExceeded += (name, calories) => { eventFired = true; };

            Recipe recipe = new Recipe("High Calorie Recipe");
            recipe.AddIngredient(new Ingredient("Sugar", 2, "cup", 1548, "Carbohydrates"));
            recipe.AddIngredient(new Ingredient("Butter", 1, "cup", 1628, "Fats"));

            // Act
            manager.AddRecipe(recipe);
            manager.CheckRecipeCalories(recipe);

            // Assert
            Assert.IsTrue(eventFired);
        }
    }
}

