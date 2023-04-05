using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostApp.AppCode
{
    public class Admin : User
    {
        public Admin()
        {

        }
        public Admin(User user)
        {
            this.Id = user.Id;
            this.Name = user.Name;
            this.Email = user.Email;
            this.UserName = user.UserName;
            this.Password = user.Password;

        }

        /*public static explicit operator Admin(User user)
        {
            //var admin = new Admin();
            return new Admin(user);

            //this.UserName = user.UserName;
            //this.Password = user.Password;
            //this.Email = user.Email;
            //this.Id = user.Id;
            //this.Name = user.Name;
        }*/

        /*public static Admin operator =(Admin admin, User user)
        {

        }*/

        public override void PrintOptions()
        {
            Console.Write("\n\n\tOptions - ");
            Console.Write("\n\t1. View All Posts");
            Console.Write("\n\t2. View All Users");
            Console.Write("\n\t3. LogOut");
        }

        private static void printSpace(int x)
        {
            for (int i = 0; i < x; i++) Console.Write(" ");
        }
        private static void PrintUser(User user)
        {
            Console.Write($"\n\t{user.Id}  {user.Name}");
            printSpace(15 - user.Name.Length);
            Console.Write($"{user.UserName}");
            printSpace(15 - user.UserName.Length);
            Console.Write($"{user.Email}");
            printSpace(40 - user.Email.Length);
        }
        public static void PrintAllUsers()
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\n\n\tId   Name           UserName       Email                    \n");
            foreach (User user in Database.users)
            {
                if (user.Id != 100)
                    PrintUser(user);
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        public static void PrintAllPosts()
        {
            App.PrintPosts();
            Console.ReadKey();
        }


    }
}
