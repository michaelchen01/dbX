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
    public class PostUser
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class UserApiController : ApiController
    {

        // POST /api/RegisterUser
        [HttpPost]
        public string Post([FromBody]PostUser input)
        {
            
            User newUser = new User();
            UserRepository userRepository = new UserRepository();

            // Initialize new User in reponse to POST request 
            // See dbx / Models / UserModel for details
            newUser.Username = input.Username;
            newUser.Email = input.Email;
            newUser.Password = input.Password;
            newUser.Coins = 0;
            newUser.FollowedBounties = new List<string>();
            newUser.OpenBounties = new List<string>();
            newUser.SolvedBounties = new List<string>();

            userRepository.AddUser(newUser); 

            return newUser.Username;
        }
    }
}
