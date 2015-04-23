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

    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {

            UserRepository userRepository = new UserRepository();
            User user = userRepository.GetUserByEmail("michael@michael.com");

            BountyRepository bountyRepository = new BountyRepository();
            List<Bounty> allBounties = bountyRepository.GetAllBounties().ToList<Bounty>();

            List<Bounty> bountiesToDisplay = new List<Bounty>();
            foreach(var bounty in allBounties)
            {
                if(!user.OpenBounties.Contains(bounty.Id))
                {
                    bountiesToDisplay.Add(bounty);
                }
            }

            List<Bounty> query = bountiesToDisplay.OrderByDescending(t => t.Coins).ToList<Bounty>();

            ViewData["AllBounties"] = query;


            ViewData["Username"] = user.Username;

            return View();
        }
    }
}