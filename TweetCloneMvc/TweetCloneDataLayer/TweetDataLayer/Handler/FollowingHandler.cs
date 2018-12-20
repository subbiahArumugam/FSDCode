using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetDataLayer.Interface;

namespace TweetDataLayer.Handler
{
    public class FollowingDataHandler:IfollowersData
    {
        public TwitterEntities entities = new TwitterEntities();

        public bool Addfollowers(string userId, string followerId)
        {
            try
            {
                entities.Followings.Add(new Following { following_id = followerId, user_id = userId });
                entities.SaveChanges();

                return true ;
            }
            catch 
            {
                
                return false;
            }
        }

        public List<Following> GetFollowers()
        {
            try
            {
                return entities.Followings.ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool Unfollow(string userId, string followerId)
        {
            try
            {
                var deleteData = entities.Followings.Where(m => m.user_id == userId && m.following_id == followerId).FirstOrDefault();
                entities.Followings.Remove(deleteData);
                return true;
            }
            catch (Exception)
            {
                return false;
                //throw;
            }
        }
    }
}
