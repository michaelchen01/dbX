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

    public class CoinPost
    {
        public string Coins { get; set; }
    }

    public class AddCoinsApiController : ApiController
    {
        [HttpPost]
        public string Post([FromBody]CoinPost input)
        {

            UserRepository userRepository = new UserRepository();
            User user = userRepository.GetUserByEmail("michael@michael.com");

            user.Coins = user.Coins + Int32.Parse(input.Coins);

            userRepository.UpdateUser(user.Id, user);
            
            return "User Updated!";
        }



    }
}
