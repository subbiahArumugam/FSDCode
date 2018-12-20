using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetCloneBusinessLayer.Object;

namespace TweetCloneBusinessLayer.Interfaces
{
    public interface IUserProfile
    {
        bool LoginUser(string UserName, string Password);

        bool UpdateUserProfile(User UserData);

        bool RegisterUser(User UserData);

        User GetUserData(string name);
    }
}
