using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenius
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        public string Title { get; set; }
        public string RecipeDescription { get; set; }
        public int CategoryID { get; set; }
        public string CookingTime { get; set; }
        public string ImagePath { get; set; }
        public List<RecipeIngredients> RecipeIngredients { get; set; }

        public Recipe(int recipeID, string title, string description, int categoryID, string cookingTime, string imagePath, List<RecipeIngredients> recipeIngredients)
        {
            RecipeID = recipeID;
            Title = title;
            RecipeDescription = description;
            CategoryID = categoryID;
            CookingTime = cookingTime;
            ImagePath = imagePath;
            RecipeIngredients = recipeIngredients;
        }

        public bool AddRecipe(string title, string description, int categoryID, TimeSpan cookingTime, string imagePath, List<RecipeIngredients> recipeIngredients)
        {
            return true;
        }

        public bool UpdateRecipe(int recipeID, string title, string description, int categoryID, TimeSpan cookingTime, string imagePath, List<RecipeIngredients> recipeIngredients)
        {
            return true;
        }

        public bool DeleteRecipe(int recipeID)
        {
            return true;
        }
       
    }
}
