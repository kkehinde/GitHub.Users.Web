using GitHub.Users.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.Users.HttpClient
{
   public interface IHttpServiceClient
    {
        Task<RawUserData> GetUserEndpoint(string endpoint);
        Task<List<UserRepo>> GetRepoEndpoint(string endpoint);
    }
}
