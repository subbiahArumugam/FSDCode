using CustomAuthenticationMVC.CustomAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TweetCloneBusinessLayer.Handler;
using TweetCloneBusinessLayer.Object;
using TwitterClone.Models;

namespace TwitterClone.Controllers
{
//test
    [CustomAuthorize]
    public class HomeController : Controller
    {
        [CustomAuthorize]
        public ActionResult Index()
        {
            var model = new TweetViewModel();

            model.UserTweetList = new List<Tweet>();
            var currentUser=this.HttpContext.User;

            var tweetlist = new TweetHandler().GetUserTweet(currentUser.Identity.Name);
            var followertweet = new TweetHandler().GetFollowersTweet(currentUser.Identity.Name);
            var followingtweet = new TweetHandler().GetFollowingTweet(currentUser.Identity.Name);

            var followerlist = new FollowersHandler().GetFollowers();


            var combinetweelist=((from usertweet in tweetlist
                                select new Tweet { UserId=usertweet.UserId, Message=usertweet.Message, Created=usertweet.Created})
                                .Union(from  follower in followertweet
                                       select new Tweet { UserId=follower.UserId, Message=follower.Message, Created=follower.Created})
                                       .Union(from  following in followingtweet
                                       select new Tweet { UserId=following.UserId, Message=following.Message, Created=following.Created})).ToList();


            model.UserTweetList=combinetweelist;

            ViewBag.FollowerCount=followerlist.Where(m=>m.Item2==currentUser.Identity.Name).Count();
            ViewBag.FollowingCount=followerlist.Where(m=>m.Item1==currentUser.Identity.Name).Count();

            return View(model);
        
        
        }
        public JsonResult AddFollower(string followerid)
        {
            var currentUser=this.HttpContext.User.Identity.Name;
            var addfollower = new FollowersHandler().Addfollowers(currentUser, followerid);

            return new JsonResult { Data = "sucess" };
        }

        


        public ActionResult Search(string usersearch)
        {
            var model = new UserModel();
            var currentUser = this.HttpContext.User;
            var usersearchdata = new  TweetCloneBusinessLayer.UserProfile().GetUserData(usersearch);

            return PartialView("Search", new UserModel { FullName = usersearchdata.FullName, UserName = usersearchdata.UserId });
        }
        [CustomAuthorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public JsonResult tweet(string tweetData)
        {
            var currentUser=this.HttpContext.User;
            var tweetHandler = new TweetHandler();

            tweetHandler.InsertUserTweet(new Tweet { Message = tweetData, Created = DateTime.Now, UserId = currentUser.Identity.Name });
            return new JsonResult { Data = "sucess" };
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
