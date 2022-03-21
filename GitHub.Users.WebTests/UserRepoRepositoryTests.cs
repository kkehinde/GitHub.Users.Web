using GitHub.Users.HttpClient;
using GitHub.Users.Model.Enums;
using GitHub.Users.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace GitHub.Users.WebTests
{
    [TestClass]
    public class UserRepoRepositoryTests
    {
        private readonly IHttpServiceClient _httpService;
        private readonly IUserGitRepos _userGitService;
        public UserRepoRepositoryTests()
        {
            _httpService = new HttpServiceClient();
            _userGitService = new UserGitRepos(_httpService);
        }
        [TestMethod]        
        public async Task Search_GitHubRepos_PassesDefaultUsername_WhenNotNull()
        {
           var returnValueItem =  await _userGitService.GetUserRepos("robconery");
            Assert.AreEqual(ErrorStatusType.NoError, returnValueItem.ErrorStatus);
        }

        [TestMethod]
        [DataRow(null, DisplayName ="Null check")]  
        [DataRow("", DisplayName ="Empty check")]
        public async Task Search_GitHubRepos_PassesUsername_WhenNullOrEmpty(string passedValue)
        {
            var returnValueItem = await _userGitService.GetUserRepos(passedValue);
            Assert.AreEqual(ErrorStatusType.NullReferenceInput, returnValueItem.ErrorStatus);

        }

        [TestMethod]
        public async Task Search_GitHubRepos_PassesUsername_UserNotFound()
        {
            string passedValue = "samuelEsther";
            var returnValueItem = await _userGitService.GetUserRepos(passedValue);

            Assert.AreEqual(ErrorStatusType.NotFound, returnValueItem.ErrorStatus);

        }
    }
}
