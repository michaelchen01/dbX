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
    public class BountyNewController : Controller
    {
        // GET: BountyNew
        public ActionResult Index()
        {
            
            UserRepository userRepository = new UserRepository();
            User user = userRepository.GetUserByEmail("michael@michael.com");

            ViewData["Username"] = user.Username;
            ViewData["Coins"] = user.Coins;
            
            return View();
        }
    }
}