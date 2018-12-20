using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetCloneBusinessLayer.Interfaces;
using TweetDataLayer.Handler;
using TweetDataLayer.Interface;

namespace TweetCloneBusinessLayer.Handler
{
    public class FollowersHandler:IFollowing
    {
        IfollowersData followerData;
        public FollowersHandler()
        {
            followerData = new FollowingDataHandler();
        }
        public FollowersHandler(IfollowersData data)
        {
            followerData = data;
        }
        public List<Tuple<string, string>> GetFollowers()
        {
            var listfollowersdata = followerData.GetFollowers();
            var finalfollowerlist = new List<Tuple<string, string>>();
            foreach (var follower in listfollowersdata)
            {
                finalfollowerlist.Add(new Tuple<string,string>(follower.user_id,follower.following_id));
            }

            return finalfollowerlist;
        }

        public bool Addfollowers(string userId, string followerId)
        {
            return followerData.Addfollowers(userId, followerId);
            
        }

        public bool Unfollow(string userId, string followerId)
        {
            return followerData.Unfollow(userId, followerId);
        }
    }
}
