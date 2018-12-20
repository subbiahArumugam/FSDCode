using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetDataLayer.Interface
{
    public interface IfollowersData
    {
        bool Addfollowers(string userId, string followerId);

        List<Following> GetFollowers();

        bool Unfollow(string userId, string followerId);
    }
}
