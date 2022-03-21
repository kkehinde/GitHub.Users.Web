using GitHub.Users.HttpClient;
using GitHub.Users.Model;
using GitHub.Users.Model.Enums;
using GitHub.Users.Model.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.Users.Repository
{
    public class UserGitRepos : IUserGitRepos
    {
        private readonly IHttpServiceClient _serviceClient;
        public UserGitRepos(IHttpServiceClient serviceClient)
        {
            _serviceClient = serviceClient;

        }

        public async Task<ResultItem<List<Repo>>> GetUserRepos(string username)
        {
            try
            {
                if (string.IsNullOrEmpty(username))
                    return await Task.FromResult(new ResultItem<List<Repo>>(null, ErrorStatusType.NullReferenceInput, $"{nameof(username)} is null"));

                var rawuserRepos = await _serviceClient.GetRepoEndpoint($"{username}/repos");

                if (rawuserRepos == null || rawuserRepos.Count == 0)
                    return await Task.FromResult(new ResultItem<List<Repo>>(null, ErrorStatusType.NotFound, "Response object is null"));


                var repos = rawuserRepos.ToRepos().Take(5).ToList();
                return await Task.FromResult(new ResultItem<List<Repo>>(repos));

            }
            catch (Exception ex)
            {

                if (!string.IsNullOrEmpty(ex.Message) && ex.Message.Contains("Not Found"))
                    return await Task.FromResult(new ResultItem<List<Repo>>(null, ErrorStatusType.NotFound, ex.Message));

                return await Task.FromResult(new ResultItem<List<Repo>>(null, ex));
            }
        }
    }
}
