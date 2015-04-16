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
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {

            UserRepository userRepository = new UserRepository();
            BountyRepository bountyRepository = new BountyRepository();
            User user = userRepository.GetUserByEmail("michael@michael.com");

            ViewData["Username"] = user.Username;
            ViewData["Coins"] = user.Coins;

            List<Bounty> followedBounties = new List<Bounty>();
            // Get the bounties from user's bounties
            foreach(string item in user.FollowedBounties)
            {
                Bounty bounty = bountyRepository.GetBounty(item);
                followedBounties.Add(bounty);
            }

            ViewData["FollowedBounties"] = followedBounties;

            List<Bounty> openBounties = new List<Bounty>();
            // Get the bounties from user's bounties
            foreach (string item in user.OpenBounties)
            {
                Bounty bounty = bountyRepository.GetBounty(item);
                openBounties.Add(bounty);
            }

            ViewData["OpenBounties"] = openBounties;

            List<Bounty> solvedBounties = new List<Bounty>();
            // Get the bounties from user's bounties
            foreach (string item in user.SolvedBounties)
            {
                Bounty bounty = bountyRepository.GetBounty(item);
                solvedBounties.Add(bounty);
            }

            ViewData["SolvedBounties"] = solvedBounties;
            
            return View(user);
        }
    }
}