using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using dbX.Models;
using dbX.Domain.Repository;

namespace dbX.Controllers
{
    public class BountyPostController : Controller
    {
        // GET: BountyPost
        public ActionResult Index()
        {
            // need to get id
            string id = "552c5e88d4a08114c0d4a905";

            BountyRepository bountyRepository = new BountyRepository(null);
            Bounty bounty = bountyRepository.GetBounty(id);
            
            return View(bounty);
        }
    }
}