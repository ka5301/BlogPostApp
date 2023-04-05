using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostApp.AppCode
{
    public static class Database
    {
        public static List<User> users = new List<User>();
        public static List<Post> posts = new List<Post>();
        public static List<Vote> votes = new List<Vote>();

        public static void BindData()
        {
            Database.users.Add(new User(100, "Abhishek", "Abhishek@watchguard.com", "123456", "admin_abhishek"));
            Database.users.Add(new User(101, "Samarth", "samarth@watchguard.com", "123456", "sjain"));
            Database.users.Add(new User(102, "Akhil", "Akhil@watchguard.com", "123456", "asingh"));
            Database.users.Add(new User(103, "Shubhankar", "Shubhankar@watchguard.com", "123456", "ssaxena"));
            Database.users.Add(new User(104, "Shivang", "Shivang@watchguard.com", "123456", "ssingh"));


            Database.posts.Add(new Post(999, "Secplicity", "Secplicity, powered by WatchGuard, is a mix of video, podcast,and editorial \n\tabout the latest threats and how to cope with them.", 101));
            Database.posts.Add(new Post(998, "Cybersecurity Trends", "Secplicity, powered by WatchGuard, is a mix of video, podcast, and editorial content \n\tabout the latest threats and how to cope with them.", 102));

            Database.votes.Add(new Vote(999, 101, 1));
            Database.votes.Add(new Vote(998, 101, 1));
            Database.votes.Add(new Vote(999, 102, 1));
            Database.votes.Add(new Vote(998, 102, 2));
            Database.votes.Add(new Vote(999, 103, 1));
            Database.votes.Add(new Vote(998, 103, 2));
            //Database.votes.Add(new Vote(999, 104, 2));
            Database.votes.Add(new Vote(998, 104, 1));


        }
    }

    

}
