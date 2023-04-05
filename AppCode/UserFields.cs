using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostApp.AppCode
{
    public partial class User : Person
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public User()
        {
            Id = new Random().Next(100, 999) + Database.users.Count;
        }
        public User(int id, string name, string email, string password, string userName)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            UserName = userName;
        }

    }
}
