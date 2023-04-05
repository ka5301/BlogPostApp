using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostApp.AppCode
{
    public partial class User
    {
        public virtual void PrintOptions()
        {
            var options = new StringBuilder();
            options.Append("\n\n\tOptions - ");
            options.Append("\n\t1. Edit Profile");
            options.Append("\n\t2. React on a Post");
            options.Append("\n\t3. Create a Post");
            options.Append("\n\t4. Delete a Post");
            options.Append("\n\t5. Your Liked Posts");
            options.Append("\n\t6. LogOut");

            App.Print(options.ToString());
        }
        private bool PrintUserPosts()
        {
            bool NotEmptyFlag = false;
            List<Post> posts = Database.posts;
            foreach (var post in posts)
            {
                App.SetConsoleColor();
                if (post.AuthorId == this.Id)
                {
                    NotEmptyFlag = true;
                    App.Print($"\n\n\tPost Id :{post.Id}\tTitle : {post.Title} ");
                    App.Print($"\n\tupVotes : {post.GetUpVotes()}\t downVotes : {post.GetDownVotes()} ");
                }
                Console.ResetColor();
            }
            return NotEmptyFlag;
        }
        private bool PrintUserLikedPosts()
        {
            bool NotEmptyFlag = false;
            List<Post> posts = Database.posts;

            var likedPosts = Database.votes.FindAll(vote => vote.UserID == this.Id && vote.voteStatus == 1);

            foreach (var p in likedPosts)
            {
                NotEmptyFlag = true;
                var pst = Database.posts.Find(post => post.Id == p.PostID);

                App.PrintPost(pst, this.Id);

            }
            return NotEmptyFlag;
        }

        public override sealed void EditProfile()
        {
            App.ComingSoon();
        }
        public void Register()
        {
            var printText = new StringBuilder();
            printText.Append("\n\n\tEnter your details : \n\n");
            printText.Append("\tName : ");
            App.Print(printText.ToString()); Name = Console.ReadLine();
            App.Print("\n\tEmail : "); Email = Console.ReadLine();

            if (this.IsAlreadyHaveAccount())
            {
                App.ShowInfoMessage("You Already have an account with this Email go and login");
                return;
            }

            App.Print("\n\tUsername : "); UserName = Console.ReadLine();

            printText.Append(Name);
            printText.Append($"\n\n\tEmail : {Email}");
            printText.Append($"\n\n\tUsername : ");


            while (!IsAvailable(UserName))
            {
                App.ShowInfoMessage("This username is not available try another one.");
                App.PrintAppName();
                App.Print(printText.ToString());
                UserName = Console.ReadLine();
            }

            Console.Write("\n\tPassword : "); Password = App.FetchPassword();

            Database.users.Add(this);

            App.ShowInfoMessage("Your account has been successfully registered!");
        }
        public void ReactPost()
        {
            App.PrintAppName();
            App.SetUser(this.Name);
            App.PrintPosts();

            var id = App.InputChoice("Enter the postID on which you want to React");

            if (int.TryParse(id, out int valid))
            {
                var postId = int.Parse(id);
                if (Database.posts.Any(post => post.Id == postId))
                {
                    int index = Database.votes.FindIndex(vote => vote.PostID == postId && vote.UserID == this.Id);
                    if(index >= 0) { Database.votes.RemoveAt(index); }
                    Vote.FeedReaction(postId,this.Id);


                }
                else { App.ShowErrorMessage("No post Exist for the entered ID"); }
            }
            else { App.ShowErrorMessage("No post Exist for the entered ID"); }
        }
        public void CreatePost()
        {
            //Program.ComingSoon();
            App.PrintAppName();
            App.SetUser(this.Name);

            Console.Write("\n\n\tCreating a new post - ");
            Console.Write("\n\n\tTitle : ");
            var title = Console.ReadLine();
            Console.Write("\n\tDescription : \n\t");
            var description = Console.ReadLine();

            var post = new Post(title,description,this.Id);

            Database.posts.Add(post);

            App.ShowInfoMessage("Your post has been successfully created.");


        }
        public void DeletePost()
        {
            App.PrintAppName();
            App.SetUser(this.Name);
            Console.Write("\n\n\tPosts created by you - ");
            var IsAny = PrintUserPosts();
            if(!IsAny)
            {
                App.ShowInfoMessage("No Post Exist to delete");
                return;
            }

            var id = App.InputChoice("Enter the postID which you want to Delete");

            if (int.TryParse(id, out int valid))
            {
                var postId = int.Parse(id);
                if (Database.posts.Any(post => post.Id == postId))
                {
                    int index = Database.posts.FindIndex(post => post.Id == postId);
                    if (index >= 0) {

                        if (App.GetConfirmation()) {
                            //DeleteVotes(postId);
                            Database.posts.RemoveAt(index);
                            App.ShowInfoMessage("Selected post is successfully deleted!");
                        }
                    }

                }
                else { App.ShowErrorMessage("No post Exist for the entered ID"); }
            }
            else { App.ShowErrorMessage("No post Exist for the entered ID"); }


        }
        public void LikedPost()
        {
            App.PrintAppName();
            App.SetUser(this.Name);
            Console.Write("\n\n\tPosts Liked by you - ");
            var IsAny = PrintUserLikedPosts();
            if(!IsAny) {
                App.ShowInfoMessage("None of the post is liked by you till now");
                return;
            }
            Console.ReadKey();
            
        }

    }
}
