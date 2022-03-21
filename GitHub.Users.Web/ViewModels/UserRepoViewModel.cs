using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitHub.Users.Web.ViewModels
{
    public class UserRepoViewModel: ErrorMessage
    {
        public UserRepoViewModel()
        {
            this.Repos = new List<Model.Repo>();
        }

        public string GitHubUsername { get; set; }
        public Model.User UserViewModel { get; set; }
        public List<Model.Repo> Repos { get; set; }


        public bool HasRepoResult
        {
            get
            {
                return Repos != null && Repos.Count > 0;
            }
        }
        public bool HasUserResult
        {
            get
            {
                return UserViewModel != null;
            }
        }
    }
}