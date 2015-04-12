using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbX.Models;

namespace dbX.Domain.Repository
{
    interface IBountyRepository
    {
        IEnumerable<Bounty> GetAllBounties();

        Bounty GetBounty(string id);

        Bounty AddBounty(Bounty newBounty);

        bool RemoveBounty(string id);

        bool UpdateBounty(string id, Bounty newBounty);
    }
}
