using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostApp.AppCode
{
    public enum VoteType
    {
        upVoted = 1, downVoted = 2
    }

    public class Vote
    {
        private readonly int _postID;
        private readonly int _userID;

        public int PostID
        {
            get { return _postID; }
        }
        public int UserID { 
            get { return _userID; } 
        }

        public readonly int voteStatus;

        public Vote(int postId,int userId, int voteType)
        {
            _postID = postId;
            _userID = userId;
            voteStatus = voteType;
        }

        public static void FeedReaction(int postId, int userId)
        {
            Console.Write("\n\n\tEnter 'u' for upVote or 'd' for downVote : ");
            var ch = Console.ReadKey().KeyChar;

            switch (ch)
            {
                case 'u':
                    Database.votes.Add(new Vote(postId, userId, 1));
                    App.ShowInfoMessage("Your Reaction is recorded");
                    break;
                case 'd':
                    Database.votes.Add(new Vote(postId, userId, 2));
                    App.ShowInfoMessage("Your Reaction is recorded");
                    break;
                default:
                    App.ShowErrorMessage("Invalid Choice Program terminated");
                    break;
            }
        }

        public static string GetPostReaction(int postId, int userId)
        {
            string status = "NULL";
            if (Database.votes.Any(vote => vote.PostID == postId && vote.UserID == userId))
            {
                var voteStatus = Database.votes.Find(vote => vote.PostID == postId && vote.UserID == userId).voteStatus;
                status = Enum.GetName(typeof(VoteType), voteStatus);
            }
            return status;
        }

        private void DeleteVotes(int postId)
        {
            foreach (var vote in Database.votes)
            {
                if (vote.PostID == postId) Database.votes.Remove(vote);
            }

        }



    }


}
