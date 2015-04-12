using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using dbX.Models;

namespace dbX.Domain.Repository
{
    public class UserRepository : IUserRepository
    {

        // Initializing objects
        MongoClient client;
        MongoServer server;
        MongoDatabase database;
        MongoCollection<User> users;


        /// <summary>
        /// Creation method for our UserRepository object
        /// </summary>
        /// <param name="connection"></param>
        public UserRepository(string connection)
        {
            if (string.IsNullOrWhiteSpace(connection))
            {
                connection = "mongodb://gugle:gugle@ds061701.mongolab.com:61701/dbxprototype";
            }
            // Creates an instance of the MongoServer with the connection URI specified
            try
            {
                client = new MongoClient(connection);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }
            // Get the server 
            try
            {
                server = client.GetServer();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }
            // Get the Prodigy database from our MongoServer
            try
            {
                database = server.GetDatabase("prodigy", WriteConcern.Acknowledged);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }
            // Get the users collection from the Prodigy database
            try
            {
                users = database.GetCollection<User>("Users");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }

        }

        /// <summary>
        /// Method to return all the users from the collection.
        /// </summary>
        /// <returns>Enumerable of the all the users.</returns>
        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                return users.FindAll();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }

            return null;
        }

        /// <summary>
        /// Method to Get a single user given User ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns User Object if found.</returns>
        public User GetUser(string id)
        {
            try
            {
                IMongoQuery query = Query.EQ("_id", id);
                return users.Find(query).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }

            return null;
        }

        /// <summary>
        /// Method to add a new user into the collection.
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns>Returns the user added.</returns>
        public User AddUser(User newUser)
        {
            // Generate a new string for the user
            try
            {
                newUser.Id = ObjectId.GenerateNewId().ToString();
                newUser.LastModified = DateTime.UtcNow;
                users.Insert(newUser);
                return newUser;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }

            return null;
        }

        /// <summary>
        /// Method to remove a user from the collection
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a boolean for true on success.</returns>
        public bool RemoveUser(string id)
        {
            try
            {
                IMongoQuery query = Query.EQ("_id", id);
                WriteConcernResult result = users.Remove(query);
                return result.DocumentsAffected == 1;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }

            return false;
        }

        /// <summary>
        /// Method to update a user given an id and new user object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newUser"></param>
        /// <returns>Return a boolean for true on success.</returns>
        public bool UpdateUser(string id, User newUser)
        {
            try
            {
                IMongoQuery query = Query.EQ("_id", id);
                newUser.LastModified = DateTime.UtcNow;
                IMongoUpdate update = Update
                    .Set("Username", newUser.Username)
                    .Set("Password", newUser.Password)
                    .Set("Email", newUser.Email)
                    .Set("Coins", newUser.Coins)
                    .Set("LastModified", newUser.LastModified);
                WriteConcernResult result = users.Update(query, update);
                return result.UpdatedExisting;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }

            return false;
        }


    }
}