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
    public class UsersRepositoryTests
    {
        private readonly IHttpServiceClient _httpService;
        private readonly IUserServices _userService;
        public UsersRepositoryTests()
        {
            _httpService = new HttpServiceClient();
            _userService = new UserServices(_httpService);
        }
        [TestMethod]        
        public async Task  Search_GitHubUsers_PassesDefaultUsername_WhenNotNull()
        {
           var returnValueItem =  await _userService.GetUser("robconery");
            Assert.AreEqual(ErrorStatusType.NoError, returnValueItem.ErrorStatus);
        }

        [TestMethod]
        [DataRow(null, DisplayName ="Null check")]  
        [DataRow("", DisplayName ="Empty check")]
        public async Task Search_GitHubUsers_PassesUsername_WhenNullOrEmpty(string passedValue)
        {
            var returnValueItem = await _userService.GetUser(passedValue);
            Assert.AreEqual(ErrorStatusType.NullReferenceInput, returnValueItem.ErrorStatus);

        }

        [TestMethod]
        public async Task Search_GitHubUsers_PassesUsername_UserNotFound()
        {
            string passedValue = "samuelEsther";
            var returnValueItem = await _userService.GetUser(passedValue);

            Assert.AreEqual(ErrorStatusType.NotFound, returnValueItem.ErrorStatus);

        }
    }
}
