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
    public class LogInPostUser
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }


    public class LogInApiController : ApiController
    {
        // POST /api/LogInApi
        [HttpPost]
        public string Post([FromBody]LogInPostUser input)
        {

            UserRepository userRepository = new UserRepository();
            User user = userRepository.GetUserByEmail(input.Email);

            if(input.Password == user.Password)
            {
                
            }

            return user.Username;
        }
    }
}
