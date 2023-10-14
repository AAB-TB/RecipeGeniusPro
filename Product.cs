using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenius
{
    public class Product
    {
            public int ProductID { get; private set; }
            public string Name { get; set; }
            public string Description { get; set; }

            
            public Product(int productID, string name, string description)
            {
                ProductID = productID;
                Name = name;
                Description = description;
            }

            
            public static bool AddProduct(string name, string description)
            {
                
                return true;
            }

            
            public bool UpdateProduct(int productID, string name, string description)
            {
                
                if (productID == ProductID)
                {
                    Name = name;
                    Description = description;
                    return true;
                }
                return false;
            }

           
            public static bool DeleteProduct(int productID)
            {
                
                return true;
            }
    }

    
}
