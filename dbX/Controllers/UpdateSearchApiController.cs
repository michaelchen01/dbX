using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using dbX.Models;
using dbX.Domain.Repository;

namespace dbX.Controllers
{
    public class UpdateSearch
    {
        public string MinimumCoins { get; set; }
        public string MaximumCoins { get; set; }
    }

    public class UpdateSearchApiController : ApiController
    {

        [HttpPost]
        public string Update(UpdateSearch update)
        {
            UserRepository userRepository = new UserRepository();
            User user = userRepository.GetUserByEmail("michael@michael.com");

            BountyRepository bountyRepository = new BountyRepository();
            List<Bounty> allBounties = bountyRepository.GetAllBounties().ToList<Bounty>();

            List<Bounty> bountiesToDisplay = new List<Bounty>();
            foreach (var bounty in allBounties)
            {
                if (!user.OpenBounties.Contains(bounty.Id))
                {
                    if(update.MinimumCoins != "")
                    {
                        var minCoins = Int32.Parse(update.MinimumCoins);

                        if(update.MaximumCoins != "")
                        {
                            var maxCoins = Int32.Parse(update.MaximumCoins);
                            if (bounty.Coins >= minCoins && bounty.Coins <= maxCoins)
                                bountiesToDisplay.Add(bounty);
                        }
                        else
                        {
                            if (bounty.Coins >= minCoins)
                                bountiesToDisplay.Add(bounty);
                        }
                    }
                    else
                    {
                        if (update.MaximumCoins != "")
                        {
                            var maxCoins = Int32.Parse(update.MaximumCoins);

                            if (bounty.Coins <= maxCoins)
                                bountiesToDisplay.Add(bounty);
                        }
                        else
                        {
                            bountiesToDisplay.Add(bounty);
                        }
                    }
                }
            }

            List<Bounty> query = bountiesToDisplay.OrderByDescending(t => t.Coins).ToList<Bounty>();

            string json = JsonConvert.SerializeObject(query);

            return json;
        }
    }
}
