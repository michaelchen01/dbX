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
    public class SolutionRepository : ISolutionRepository
    {
         // Initializing objects
        MongoClient client;
        MongoServer server;
        MongoDatabase database;
        MongoCollection<Solution> solutions;


        /// <summary>
        /// Creation method for our UserRepository object
        /// </summary>
        /// <param name="connection"></param>
        public SolutionRepository()
        {
            var connection = "mongodb://gugle:gugle@ds061701.mongolab.com:61701/dbxprototype";
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
                database = server.GetDatabase("dbxprototype", WriteConcern.Acknowledged);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }
            // Get the users collection from the Prodigy database
            try
            {
                solutions = database.GetCollection<Solution>("Solutions");
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
        public IEnumerable<Solution> GetAllSolutions(string userId, string bountyId)
        {
            try
            {
                IMongoQuery query = Query.And(
                    Query.EQ("BountyId", bountyId),
                    Query.EQ("UserId", userId)
                );
                return solutions.Find(query).ToList<Solution>();
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
        public Solution GetSolution(string id)
        {
            try
            {
                IMongoQuery query = Query.EQ("_id", id);

                return solutions.Find(query).FirstOrDefault();
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
        /// <param name="newSolution"></param>
        /// <returns>Returns the user added.</returns>
        public Solution AddSolution(Solution newSolution)
        {
            // Generate a new string for the user
            try
            {
                newSolution.Id = ObjectId.GenerateNewId().ToString();
                newSolution.LastModified = DateTime.UtcNow;
                solutions.Insert(newSolution);
                return newSolution;
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
        public bool RemoveSolution(string id)
        {
            try
            {
                IMongoQuery query = Query.EQ("_id", id);
                WriteConcernResult result = solutions.Remove(query);
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
        /// <param name="newSolution"></param>
        /// <returns>Return a boolean for true on success.</returns>
        public bool UpdateSolution(string id, Solution newSolution)
        {
            try
            {
                IMongoQuery query = Query.EQ("_id", id);
                newSolution.LastModified = DateTime.UtcNow;
                IMongoUpdate update = Update
                    .Set("Description", newSolution.Description)
                    .Set("Code", newSolution.Code)
                    .Set("LastModified", DateTime.UtcNow);
                WriteConcernResult result = solutions.Update(query, update);
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