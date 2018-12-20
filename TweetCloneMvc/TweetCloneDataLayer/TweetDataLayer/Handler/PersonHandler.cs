using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetDataLayer.Interface;

namespace TweetDataLayer.Handler
{
    public  class PersonDataHandler:IPersonProfileData
    {
        public TwitterEntities tweetEntitis = new TwitterEntities();

        public bool Verifyperson(string UserId, string Password)
        {
            try
            {
                var userData=tweetEntitis.People.Where(m => m.password == m.password && m.user_id == UserId).SingleOrDefault();

                if (userData == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
               // throw;
            }
        }

        public bool RegsterPerson(Person Person)
        {
            try
            {
                tweetEntitis.People.Add(Person);
                tweetEntitis.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }

            throw new NotImplementedException();
        }

        public bool UpdatePersonProfile(Person Person)
        {
           var personEntity= tweetEntitis.People.Where(m => m.user_id == Person.user_id).Single();
           tweetEntitis.People.Remove(personEntity);
           tweetEntitis.People.Add(Person);
           return true;
        }

        public Person GetPersonData(string SearchString)
        {
            try
            {
                return tweetEntitis.People.Where(m => m.user_id == SearchString || m.fullname == SearchString).Single();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
