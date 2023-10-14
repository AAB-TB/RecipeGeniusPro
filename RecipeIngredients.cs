using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenius
{
    public class RecipeIngredients
    {
        public int RecipeIngredientID { get; set; }
        public int RecipeID { get; set; }
        public int ProductID { get; set; }
        public string Quantity { get; set; }
    }
}
