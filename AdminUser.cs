using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenius
{
    public class AdminUser : User
    {
        public AdminUser(int userID, string username, string password) : base(userID, username, password, true)
        {
            
        }
    }
}
