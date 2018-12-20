using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetDataLayer.Interface;

namespace TweetDataLayer.Handler
{
    public class TweetDataHandler:ITweetData
    {
        public TwitterEntities entities = new TwitterEntities();

     


        public List<Tweet> GetTweetList()
        {
            return entities.Tweets.ToList();
        }

        public bool InsertTweet(Tweet tweet)
        {
            try
            {
                entities.Tweets.Add(tweet);
                entities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateTweet(Tweet tweet)
        {
            try
            {
                entities.Tweets.Remove(tweet);
                entities.Tweets.Add(tweet);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Tweet GetTweetUser(string UserId)
        {
            try
            {
                return entities.Tweets.Where(m => m.user_id == UserId).ToList().SingleOrDefault();
                //return new Tweet { user_id = userTweet.user_id, created = userTweet.created, message = userTweet.message, tweet_id = userTweet.tweet_id };
            }
            catch
            {
                throw;
            }
        }
    }
}
