using GitHub.Users.Model.Enums;
using GitHub.Users.Repository;
using GitHub.Users.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GitHub.Users.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IUserGitRepos _userGitRepos;
        public HomeController(IUserServices userServices, IUserGitRepos userGitRepos)
        {
            _userServices = userServices;
            _userGitRepos = userGitRepos;
        }

        [HttpGet]
        public ActionResult Index()
        {
            UserRepoViewModel viewModel = new UserRepoViewModel();
            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Index(UserRepoViewModel viewModel)
        {
            Model.ResultItem<Model.User> gitUserItem = null;
            Model.ResultItem<List<Model.Repo>> gitRepoItem = null;

            Parallel.Invoke(
                () =>
                {
                    gitUserItem = _userServices.GetUser(viewModel.GitHubUsername).Result;
                },
                () =>
                {
                    gitRepoItem = _userGitRepos.GetUserRepos(viewModel.GitHubUsername).Result;
                });

            UserRepoViewModel model = null;

            if (gitUserItem.ErrorStatus != ErrorStatusType.NoError)
            {
                model = new UserRepoViewModel
                {
                    Failed = true,
                    Message = $"The input user {viewModel.GitHubUsername} is not found.  Error details: {gitUserItem.Error.Message}",
                    GitHubUsername = viewModel.GitHubUsername,
                    Repos = new List<Model.Repo>(),
                    UserViewModel = null
                };
                return View(model);
            }

            if (gitRepoItem.ErrorStatus != ErrorStatusType.NoError)
            {
                model = new UserRepoViewModel
                {
                    Failed = true,
                    Message = $"No repo found for this user:  {viewModel.GitHubUsername}. Error Detail: {gitRepoItem.Error.Message}",
                    GitHubUsername = viewModel.GitHubUsername,
                    Repos = new List<Model.Repo>(),
                    UserViewModel = gitUserItem.Item
                };
                return View(model);
            }

          

            model = new UserRepoViewModel
            {
                GitHubUsername = viewModel.GitHubUsername,
                Repos = gitRepoItem.Item,
                UserViewModel = gitUserItem.Item,
            };

            return View(model);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}