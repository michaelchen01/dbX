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

            int bountyCount = 0;
            List<Bounty> featuredBounties = new List<Bounty>();
            foreach(var bounty in user.OpenBounties)
            {
                Bounty temp = bountyRepository.GetBounty(bounty);
                if(bountyCount < 3)
                {
                    featuredBounties.Add(temp);
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
