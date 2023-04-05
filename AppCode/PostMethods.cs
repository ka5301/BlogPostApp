using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostApp.AppCode
{
    public partial class Post
    {
        public int GetUpVotes()
        {
            return Database.votes.Count(vote => vote.PostID == Id && vote.voteStatus == 1);

        }

        public int GetDownVotes()
        {
            return Database.votes.Count(vote => vote.PostID == Id && vote.voteStatus == 2);
        }

    }
}
