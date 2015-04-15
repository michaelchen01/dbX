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

            string id = "552c5e88d4a08114c0d4a905";

            UserRepository userRepository = new UserRepository();
            User user = userRepository.GetUser(id);

            ViewData["Username"] = user.Username;
            ViewData["Coins"] = user.Coins;
            ViewData["FollowedBounties"] = user.FollowedBounties;
            ViewData["OpenBounties"] = user.OpenBounties;
            ViewData["SolvedBounties"] = user.SolvedBounties;
            
            return View(user);
        }
    }
}