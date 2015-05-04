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
    public class EditBountyApiController : ApiController
    {
        public class EditBounty
        {
            public string Id { get; set; }

            public string Title { get; set; }

            public string Background { get; set; }

            public string Task { get; set; }

            public List<string> Tags { get; set; }

            public string Price { get; set; }

            public string Code { get; set; }

            public string EndTime { get; set; }

            public string Difficulty { get; set; }
        }

        [HttpPost]
        public string Post([FromBody]EditBounty submitBounty)
        {
            // Create the new bounty in the database
            BountyRepository bountyRepository = new BountyRepository();
            UserRepository userRepository = new UserRepository();
            Bounty bounty = new Bounty();

            bounty.Id = submitBounty.Id;
            bounty.Title = submitBounty.Title;
            bounty.Background = submitBounty.Background;
            bounty.Difficulty = submitBounty.Difficulty;
            bounty.Task = submitBounty.Task;
            bounty.Coins = Int32.Parse(submitBounty.Price);
            bounty.Code = submitBounty.Code;
            bounty.EndTime = DateTime.Parse(submitBounty.EndTime);
            bounty.Tags = submitBounty.Tags;

            bountyRepository.UpdateBounty(bounty.Id,bounty);

            return "Bounty Updated!";
        }
    }
}
