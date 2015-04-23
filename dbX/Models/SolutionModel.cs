using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

namespace dbX.Models
{
    public class SolutionModel
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }
    }
}