﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetCloneBusinessLayer.Object
{
    public class User
    {
        public string UserId { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime JoinedDate { get; set; }

        public bool Active { get; set; }
    }
}
