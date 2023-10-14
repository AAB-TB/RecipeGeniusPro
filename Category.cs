using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenius
{
   
        public class Category
        {
         
            public int CategoryID { get; private set; }
            public string Name { get; set; }

            
            public Category(int categoryID, string name)
            {
                CategoryID = categoryID;
                Name = name;
            }

            
            public static bool AddCategory(string name)
            {
                
                return true;
            }

            
            public bool UpdateCategory(int categoryID, string name)
            {
                
                if (categoryID == CategoryID)
                {
                    Name = name;
                    return true;
                }
                return false;
            }

            
            public static bool DeleteCategory(int categoryID)
            {
                return true;
            }
        }

    
}
