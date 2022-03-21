using GitHub.Users.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.Users.Repository
{
    public interface  IUserServices
    {
        Task<ResultItem<User>> GetUser(string username);
    }
}
