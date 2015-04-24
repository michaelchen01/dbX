using System;
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
    public class BountySolution
    {
        public string UserId { get; set; }
        public string BountyId { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
    }

    public class SubmitBountySolutionApiController : ApiController
    {
        [HttpPost]
        public string Post([FromBody]BountySolution bountySolution)
        {
            BountyRepository bountyRepository = new BountyRepository();
            SolutionRepository solutionRepository = new SolutionRepository();

            Solution solution = new Solution();

            solution.BountyId = bountySolution.BountyId;
            solution.UserId = bountySolution.UserId;
            solution.Description = bountySolution.Description;
            solution.Code = bountySolution.Code;

            solutionRepository.AddSolution(solution);

            return "Solution Added!";
        }
    }
}
