using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenius
{
    public class User
    {
        public int UserID { get; private set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        // Constructor
        public User(int userID, string username, string password, bool isAdmin)
        {
            UserID = userID;
            Username = username;
            Password = password;
            IsAdmin = isAdmin;
        }

        // Method to simulate user login
        public bool Login(string username, string password)
        {
            // Implementation to check if the provided username and password are valid
            // Replace this with your actual authentication logic
            if (Username == username && Password == password)
            {
                return true;
            }
            return false;
        }
    }
}
