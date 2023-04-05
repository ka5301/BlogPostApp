using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostApp.AppCode
{
    internal class UI
    {
        public static void AdminLoginPage()
        {
            App.PrintAppName();
            //User user = new Admin();
            var user = new User();
            user.UserName = "admin_abhishek";
            App.Print($"\n\n\tUsername : {user.UserName}");
            App.Print("\n\tPassword : "); user.Password = App.FetchPassword();

            if (user.IsValid())
            {
                user = Database.users.FirstOrDefault(usr => usr.UserName == user.UserName);

                

                /*Admin admin = new Admin();

                admin = (Admin) user;*/

                /*admin.UserName = user.UserName;
                admin.Password = user.Password;
                admin.Name = user.Name;
                admin.Id = user.Id;
                admin.Email = admin.Email;*/

                Admin admin = new Admin(user);

                //admin = user;

                /*Admin A = new Admin();
                User B = new User();
                Admin C = new User();
                User D = new Admin();*/

                //Admin admin = user;

                AdminHomePage(admin);
            }

            else { App.ShowErrorMessage("Invalid Credentials!"); }

        }
        public static void AdminHomePage(Admin user)
        {
        HomeStart:
            App.PrintAppName();
            App.SetUser(user.Name);
            user.PrintOptions();

            var choice = App.InputChoice("Enter your choice");
            switch (choice)
            {
                case "1":
                    Admin.PrintAllPosts();
                    break;
                case "2":
                    Admin.PrintAllUsers();
                    break;
                case "3":
                    if (user.DoLoggedOut()) return;
                    break;
                default:
                    App.ShowErrorMessage("Please enter the correct choice!");
                    break;
            }
            goto HomeStart;

            //Exercise2.Execute();
        }

        public static void UserLoginPage()
        {
            App.PrintAppName();
            var user = new User();
            App.Print("\n\n\tUsername : "); user.UserName = Console.ReadLine();
            App.Print("\n\tPassword : "); user.Password = App.FetchPassword();

            if (user.IsValid())
            {
                user = Database.users.FirstOrDefault(usr => usr.UserName == user.UserName);
                UserHomePage(user);
            }

            else { App.ShowErrorMessage("Invalid Credentials!"); }

        }
        public static void UserHomePage(User user)
        {
        HomeStart:
            App.PrintAppName();
            App.SetUser(user.Name);
            App.PrintPosts(user.Id);

            user.PrintOptions();
            var choice = App.InputChoice("Enter your choice");
            switch (choice)
            {
                case "1":
                    if (user.IsValidProfileEdition()) user.EditProfile();
                    else App.ShowErrorMessage("Invalid Access!");
                    break;
                case "2":
                    user.ReactPost();
                    break;
                case "3":
                    user.CreatePost();
                    break;
                case "4":
                    user.DeletePost();
                    break;
                case "5":
                    user.LikedPost();
                    break;
                case "6":
                    if (user.DoLoggedOut()) return;
                    break;
                default:
                    App.ShowErrorMessage("Please enter the correct choice!");
                    break;
            }
            goto HomeStart;

        }

        public static void RegisterUserPage()
        {
            App.PrintAppName();
            var user = new User();
            user.Register();

            UserLoginPage();
        }

        public static void IndexPage()
        {
        IndexStart:
            App.PrintAppName();
            App.Print("\n\n\t1. Login");
            App.Print("\n\t2. Register");
            App.Print("\n\t3. Exit");

            var choice = App.InputChoice("Enter your choice");
            switch (choice)
            {
                case "1":
                    UserLoginPage();
                    break;
                case "2":
                    RegisterUserPage();
                    break;
                case "3":
                    App.Print("\n\n\t");
                    return;
                case "a":
                    AdminLoginPage();
                    break;
                default:
                    App.ShowErrorMessage("Please enter the correct choice");
                    break;
            }
            goto IndexStart;
        }

    }
}
