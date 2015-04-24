using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbX.Models;

namespace dbX.Domain.Repository
{
    interface ISolutionRepository
    {
        IEnumerable<Solution> GetAllSolutions(string userId, string bountyId);

        Solution GetSolution(string id, string bountyId);

        Solution AddSolution(Solution newUser);

        bool RemoveSolution(string id);

        bool UpdateSolution(string id, Solution newUser);
    }
}
