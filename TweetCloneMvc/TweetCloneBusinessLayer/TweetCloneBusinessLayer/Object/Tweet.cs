using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetCloneBusinessLayer.Object
{
    public class Tweet
    {
        public int TweetId { get; set; }

        public string UserId { get; set; }

        public string Message { get; set; }

        public DateTime Created { get; set; }
    }
}
