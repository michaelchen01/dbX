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
    public class BountyRepository : IBountyRepository
    {

        // Initializing objects
        MongoClient client;
        MongoServer server;
        MongoDatabase database;
        MongoCollection<Bounty> bounties;


        /// <summary>
        /// Creation method for our BountyRepository object
        /// </summary>
        /// <param name="connection"></param>
        public BountyRepository(string connection)
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
            // Get the Bountys collection from the Prodigy database
            try
            {
                bounties = database.GetCollection<Bounty>("Bounties");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }

        }

        /// <summary>
        /// Method to return all the bounties from the collection.
        /// </summary>
        /// <returns>Enumerable of the all the bounties.</returns>
        public IEnumerable<Bounty> GetAllBounties()
        {
            try
            {
                return bounties.FindAll();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }

            return null;
        }

        /// <summary>
        /// Method to Get a single Bounty given Bounty ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns Bounty Object if found.</returns>
        public Bounty GetBounty(string id)
        {
            try
            {
                IMongoQuery query = Query.EQ("_id", id);
                return bounties.Find(query).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }

            return null;
        }

        /// <summary>
        /// Method to add a new Bounty into the collection.
        /// </summary>
        /// <param name="newBounty"></param>
        /// <returns>Returns the Bounty added.</returns>
        public Bounty AddBounty(Bounty newBounty)
        {
            // Generate a new string for the Bounty
            try
            {
                newBounty.Id = ObjectId.GenerateNewId().ToString();
                newBounty.LastModified = DateTime.UtcNow;
                bounties.Insert(newBounty);
                return newBounty;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }

            return null;
        }

        /// <summary>
        /// Method to remove a Bounty from the collection
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a boolean for true on success.</returns>
        public bool RemoveBounty(string id)
        {
            try
            {
                IMongoQuery query = Query.EQ("_id", id);
                WriteConcernResult result = bounties.Remove(query);
                return result.DocumentsAffected == 1;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }

            return false;
        }

        /// <summary>
        /// Method to update a Bounty given an id and new Bounty object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newBounty"></param>
        /// <returns>Return a boolean for true on success.</returns>
        public bool UpdateBounty(string id, Bounty newBounty)
        {
            try
            {
                IMongoQuery query = Query.EQ("_id", id);
                newBounty.LastModified = DateTime.UtcNow;
                IMongoUpdate update = Update
                    .Set("Background", newBounty.Background)
                    .Set("Task", newBounty.Task)
                    .Set("Coins", newBounty.Coins)
                    .Set("EndTime", newBounty.EndTime)
                    .Set("Tags", BsonArray.Create(newBounty.Tags))
                    .Set("LastModified", newBounty.LastModified);
                WriteConcernResult result = bounties.Update(query, update);
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