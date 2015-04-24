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
    public class ViewSolutionController : Controller
    {
        // GET: ViewSolution
        public ActionResult Index(string solutionId)
        {

            UserRepository userRepository = new UserRepository();
            BountyRepository bountyRepository = new BountyRepository();
            SolutionRepository solutionRepository = new SolutionRepository();

            User user = userRepository.GetUserByEmail("michael@michael.com");
            ViewData["Username"] = user.Username;

            Solution solution = solutionRepository.GetSolution(solutionId);
            Bounty bounty = bountyRepository.GetBounty(solution.BountyId);

            ViewData["BountyTitle"] = bounty.Title;

            ViewData["Description"] = solution.Description;
            ViewData["Code"] = solution.Code;

            ViewData["LastModified"] = solution.LastModified.ToLongDateString();

            return View();
        }
    }
}