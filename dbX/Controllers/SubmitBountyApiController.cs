﻿using System;
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
    public class SubmitBounty
    {
        public string Title { get; set; }

        public string Background { get; set; }

        public string Task { get; set; }

        public string Price { get; set; }

        public string EndTime { get; set; }
    }

    public class SubmitBountyApiController : ApiController
    {

        // POST /api/SubmitBountyApi
        [HttpPost]
        public string Post([FromBody]SubmitBounty submitBounty)
        {

            BountyRepository bountyRepository = new BountyRepository();
            Bounty bounty = new Bounty();

            bounty.Title = submitBounty.Title;
            bounty.Background = submitBounty.Background;
            bounty.Difficulty = "";
            bounty.Task = submitBounty.Task;
            bounty.Coins = Int32.Parse(submitBounty.Price);
            bounty.EndTime = DateTime.Parse(submitBounty.EndTime);
            bounty.Tags = new List<string>();

            bountyRepository.AddBounty(bounty);

            return "Bounty Added!";
        }

    }
}