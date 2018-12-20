using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetCloneBusinessLayer.Interfaces
{
    public interface IFollowing
    {
        List<Tuple<string,string>> GetFollowers();

        bool Addfollowers(string userId, string followerId);

        bool Unfollow(string userId, string followerId);
    }
}
