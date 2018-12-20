using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetDataLayer.Interface
{
    public interface IPersonProfileData
    {
        bool Verifyperson(string UserId, string Password);

        bool RegsterPerson(Person Person);


        bool UpdatePersonProfile(Person Person);

        Person GetPersonData(string SearchString);
    }
}
