using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TweetCloneBusinessLayer.Object;

namespace TwitterClone.Models
{
    public class TweetViewModel
    {
        public List<Tweet> UserTweetList { get; set; }

        public List<Tweet> FollowesTweet { get; set; }
    }
}