using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dbX.Models
{
    public class Bounty
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Difficulty { get; set; }

        public string Background { get; set; }

        public string Task { get; set; }

        public int Coins { get; set; }

        public List<string> Tags { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime LastModified { get; set; }
    }
}