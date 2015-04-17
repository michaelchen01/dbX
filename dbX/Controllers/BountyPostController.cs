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
        public ActionResult Index(string bountyId, int owner)
        {
            // need to get id
            string id = bountyId;

            BountyRepository bountyRepository = new BountyRepository();
            UserRepository userRepository = new UserRepository();

            User user = userRepository.GetUserByEmail("michael@michael.com");
            Bounty bounty = bountyRepository.GetBounty(id);

            ViewData["Username"] = user.Username;

            ViewData["Owner"] = owner;

            ViewData["Title"] = bounty.Title;
            ViewData["Background"] = bounty.Background;
            ViewData["Task"] = bounty.Task;
            ViewData["Coins"] = bounty.Coins;
            ViewData["EndTime"] = bounty.EndTime;
            ViewData["Tags"] = bounty.Tags;

            return View(bounty);
        }
    }
}