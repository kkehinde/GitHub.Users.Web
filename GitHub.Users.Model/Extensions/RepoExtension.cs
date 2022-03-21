using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.Users.Model.Extensions
{
    public static class RepoExtension
    {
        public static  List<Repo> ToRepos(this  List<UserRepo> userRepos)
        {

            if (userRepos == null || userRepos.Count == 0)
                return null;

            var repos = userRepos.Select(c => c.ToRepo()).OrderByDescending(p=>p.StargazersCount).ToList();

            return repos;
        }

        public static Repo ToRepo(this UserRepo userRepo)
        {
            Repo repo = new Repo
            {
                CreatedAt = userRepo.CreatedAt,
                Description = userRepo.Description,
                FullName = userRepo.FullName,
                Name = userRepo.Name,
                NodeId = userRepo.NodeId,
                Private = userRepo.Private,
                PushedAt = userRepo.PushedAt,
                StargazersCount = userRepo.StargazersCount,
                StargazersUrl = userRepo.StargazersUrl,
                UpdatedAt = userRepo.UpdatedAt,
                Id = userRepo.Id,
                 Url = userRepo.Url
            };

            return repo;
        }

    }
}
