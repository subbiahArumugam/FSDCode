using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetDataLayer.Interface
{
    public interface ITweetData
    {
         List<Tweet> GetTweetList();

        bool InsertTweet(Tweet tweet);

        bool UpdateTweet(Tweet tweet);

        Tweet GetTweetUser(string UserId);

    }
}
