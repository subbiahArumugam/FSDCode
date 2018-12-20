using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetCloneBusinessLayer.Interfaces;
using TweetCloneBusinessLayer.Object;
using TweetDataLayer;
using TweetDataLayer.Handler;

namespace TweetCloneBusinessLayer
{
    public class UserProfile : IUserProfile
    {
        public bool LoginUser(string UserName, string Password)
        {
            return new PersonDataHandler().Verifyperson(UserName, Password);
        }

        public bool UpdateUserProfile(Object.User UserData)
        {
            return new PersonDataHandler().UpdatePersonProfile(new Person { user_id = UserData.UserId, fullname = UserData.FullName, password = UserData.Password, email = UserData.Email, joined = UserData.JoinedDate, active = true });
        }


        public bool RegisterUser(Object.User UserData)
        {
            return new PersonDataHandler().RegsterPerson(new Person { user_id = UserData.UserId, fullname = UserData.FullName, password = UserData.Password, email = UserData.Email, joined = UserData.JoinedDate, active = true });
        }


        public Object.User GetUserData(string name)
        {
            var userdata= new PersonDataHandler().GetPersonData(name );
            return new User { UserId = userdata.user_id, Password = userdata.password, JoinedDate = userdata.joined, Email = userdata.email, FullName = userdata.fullname };
        }
    }
}
