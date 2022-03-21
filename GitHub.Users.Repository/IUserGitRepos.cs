using GitHub.Users.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHub.Users.Repository
{
    public interface IUserGitRepos
    {
        Task<ResultItem<List<Repo>>> GetUserRepos(string username);
    }
}