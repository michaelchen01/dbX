using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using dbX.Models;
using dbX.Domain.Repository;

namespace dbX.Controllers
{
    public class FollowBounty
    {
        public string BountyId { get; set; }
    }

    public class FollowBountyApiController : ApiController
    {
        // POST /api/SubmitBountyApi
        [HttpPost]
        public string Post([FromBody]FollowBounty followBounty)
        {
            UserRepository userRepository = new UserRepository();
            User user = userRepository.GetUserByEmail("michael@michael.com");

            if(user.FollowedBounties.Contains(followBounty.BountyId))
            {
                user.FollowedBounties.Add(followBounty.BountyId);

                userRepository.UpdateUser(user.Id, user);
            }

            return "Successfully Followed Bounty";
        }
    }
}
