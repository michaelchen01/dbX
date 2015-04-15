using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dbX.Models
{
    public class Bounty
    {
        // Do we need a unique numeric ID? 

        public string Id { get; set; }

        public string Background { get; set; }

        public string Task { get; set; }

        public int Coins { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime LastModified { get; set; }
    }
}