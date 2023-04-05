using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostApp.AppCode
{
    public partial class User
    {
        private bool IsAlreadyHaveAccount()
        {
            return Database.users.Any(user => user.Email == this.Email);
        }
        private static bool IsAvailable(string username)
        {
            return !Database.users.Any(user => user.UserName == username);
        }
        public bool IsValid()
        {
            return Database.users.Any(user => user.UserName == this.UserName && user.Password == this.Password);
        }
        public bool DoLoggedOut()
        {
            return App.GetConfirmation();
        }
        public bool IsValidProfileEdition()
        {
            App.PrintAppName();
            App.SetUser(this.Name);
            App.Print("\n\n\tEnter the Password to Edit Profile : ");
            var password = App.FetchPassword();
            return password == this.Password;
        }

        
    }
}
