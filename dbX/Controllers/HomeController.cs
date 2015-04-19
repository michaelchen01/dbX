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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "dbX";

            UserRepository userRepository = new UserRepository();
            User user = userRepository.GetUserByEmail("michael@michael.com");

            BountyRepository bountyRepository = new BountyRepository();
            List<Bounty> bounties = bountyRepository.GetAllBounties().ToList<Bounty>();

            int bountyCount = 0;
            List<Bounty> featuredBounties = new List<Bounty>();
            foreach(var bounty in bounties)
            {
                if(bountyCount < 3)
                {
                    featuredBounties.Add(bounty);
                    bountyCount++;
                }
                else
                {
                    break;
                }
            }

            ViewData["FeaturedBounties"] = featuredBounties;
            ViewData["Username"] = user.Username;

            return View();
        }
    }
}
