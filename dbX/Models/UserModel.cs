using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

namespace dbX.Models
{
    public class User
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int Coins { get; set; }

        public List<string> FollowedBounties { get; set; }

        public List<string> OpenBounties { get; set; }

        public List<string> SolvedBounties { get; set; }

        public DateTime LastModified { get; set; }
    }
}