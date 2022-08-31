using InternBA.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternBA.Application.Interfaces
{
    internal interface IUserService
    {
        UserViewModel GetUsers();
    }
}
