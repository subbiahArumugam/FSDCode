using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetCloneBusinessLayer.Object;

namespace TweetCloneBusinessLayer.Interfaces
{
    public interface ITweet
    {
        List<Tweet> GetUserTweet(string UserId);

        List<Tweet> GetFollowersTweet(string UserId);

        List<Tweet> GetFollowingTweet(string UserId);

        bool InsertUserTweet(Tweet tweet);

        bool UpdateUserTweet(Tweet tweet);
    }
}
