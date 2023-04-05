using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostApp.AppCode
{
    internal class App
    {
        public static void Start()
        {
            Database.BindData();
            UI.IndexPage();
        }

        private static void ShowMessage(string message)
        {
            Console.WriteLine("\n\n\t" + message);
            Console.Write("\n\n\tPress any key to continue..");
            Console.ReadKey();
        }
        public static void ShowInfoMessage(string message)
        {
            ShowMessage(message);
        }
        public static void ShowErrorMessage(string message)
        {
            ShowMessage(message);
        }
        

        public static void Print(string text)
        {
            Console.Write(text);
        }
        public static string InputChoice(string info)
        {
            Console.Write("\n\n\t" + info + " : ");
            var choice = Console.ReadLine();
            return choice;
        }

        public static void ComingSoon()
        {
            Console.Clear();
            ShowMessage("Options will be comming soon");
        }
        public static void PrintAppName()
        {
            Console.Clear();
            Console.Write("\n\tWelcome to the BlogPost App");
        }
        public static void SetUser(string Name)
        {
            App.Print($"\tLogged in as {Name}");
        }

        public static void SetConsoleColor()
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void PrintPost(Post post, int userId = 0)
        {
            SetConsoleColor();

            var authorId = Database.posts.FirstOrDefault(p => p.Id == post.Id).AuthorId;
            var authorName = Database.users.Find(user => user.Id == authorId).Name;

            Print($"\n\n\tPost Id :{post.Id}\t\t\tPublished By : {authorName} ");
            Print($"\n\tTitle : {post.Title}\t Published At: {post.PublishedAt.ToString("dd/MM/yyyy hh:mm ddd")} ");
            Print($"\n\tDescription : \n\t{post.Description}");
            Print($"\n\tupVotes : {post.GetUpVotes()}\t downVotes : {post.GetDownVotes()} ");

            if (userId != 0)
            {
                var status = Vote.GetPostReaction(post.Id, userId);
                Print($"\t VoteStatus : {status} ");
            }

            Console.ResetColor();
        }
        public static void PrintPosts(int userId = 0)
        {
            List<Post> posts = Database.posts;
            Print("\n\n\tPosts - ");
            foreach (var post in posts)
            {
                PrintPost(post, userId);
            }
        }


        private static void PasswordBackspaceKey(ref StringBuilder password)
        {
            if (password.Length > 0)
            {
                password.Remove(password.Length - 1, 1);
            }
        }
        public static string FetchPassword()
        {
            StringBuilder password = new StringBuilder();
            while (true)
            {
                var key = Console.ReadKey(true).KeyChar;
                if (key == '\b')
                {
                    PasswordBackspaceKey(ref password);
                    continue;
                }
                if (key == '\r') break;
                password.Append(key.ToString());
                //Console.Write(key);
                Print("*");

            }

            return password.ToString();

        }
        public static bool GetConfirmation()
        {
            Print("\n\tAre you sure (y/n)"); 
            var key = Console.ReadKey(true).KeyChar;
            return (key == 'y');
        }

    }
}
