using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternBA.Domain.Interfaces
{
    internal interface IUserRepository
    {
        IEnumerable<User> GetUsers();
    }
}
