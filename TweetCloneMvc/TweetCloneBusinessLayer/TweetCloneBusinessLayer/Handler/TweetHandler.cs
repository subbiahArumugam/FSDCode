using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetCloneBusinessLayer.Interfaces;
using TweetCloneBusinessLayer.Object;
using TweetDataLayer.Handler;
using TweetDataLayer.Interface;

namespace TweetCloneBusinessLayer.Handler
{
    public class TweetHandler:ITweet
    {
        public ITweetData tweetData;
        public IfollowersData follower;
        public TweetHandler()
        {
            tweetData = new TweetDataHandler();
            follower = new FollowingDataHandler();
        }
        public List<Object.Tweet> GetUserTweet(string UserId)
        {
            var tweetlist = new List<Tweet>();
            var userTweet = tweetData.GetTweetList().Where(m => m.user_id == UserId).ToList();
            foreach (var tweet in userTweet)
            {
                tweetlist.Add(new Tweet { UserId = tweet.user_id, Message = tweet.message, TweetId = tweet.tweet_id, Created = tweet.created });
            }
            return tweetlist;
        }

        public List<Object.Tweet> GetFollowersTweet(string UserId)
        {
            var listfollowingTweet = new List<Tuple<string, string>>();
            var followers = follower.GetFollowers().ToList().Where(m => m.following_id == UserId).ToList();
            var tweetlist = tweetData.GetTweetList();
            var followertweetList = from tweet in tweetlist
                                    join followerdata in followers
                                    on tweet.user_id equals followerdata.following_id
                                    select new Tweet  {  Created=tweet.created, TweetId=tweet.tweet_id, Message=tweet.message, UserId=tweet.user_id};

            return followertweetList.ToList();
        }

        public List<Object.Tweet> GetFollowingTweet(string UserId)
        {

            var listfollowingTweet = new List<Tuple<string, string>>();
            var followers = follower.GetFollowers().ToList().Where(m => m.user_id == UserId).ToList();
            var tweetlist = tweetData.GetTweetList();
            var followertweetList = from tweet in tweetlist
                                    join followerdata in followers
                                    on tweet.user_id equals followerdata.user_id
select new Tweet { Created = tweet.created, TweetId = tweet.tweet_id, Message = tweet.message, UserId = tweet.user_id };

            return followertweetList.ToList();
        }

        public bool InsertUserTweet(Object.Tweet tweet)
        {
            return tweetData.InsertTweet(new TweetDataLayer.Tweet { user_id = tweet.UserId, message = tweet.Message, tweet_id = tweet.TweetId, created = tweet.Created });
        }

        public bool UpdateUserTweet(Object.Tweet tweet)
        {
            return tweetData.UpdateTweet(new TweetDataLayer.Tweet { user_id = tweet.UserId, message = tweet.Message, created = tweet.Created, tweet_id = tweet.TweetId });
        }
    }
}
