using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbX.Models;

namespace dbX.Domain.Repository
{
    interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();

        User GetUser(string id);

        User AddUser(User newUser);

        bool RemoveUser(string id);

        bool UpdateUser(string id, User newUser);
    }
}