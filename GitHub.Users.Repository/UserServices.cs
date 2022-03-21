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
    public class UserServices : IUserServices
    {
        private readonly IHttpServiceClient _serviceClient;
        public UserServices(IHttpServiceClient serviceClient)
        {
            _serviceClient = serviceClient;

        }
        public async Task<ResultItem<User>> GetUser(string username)
        {
            try
            {

                if (string.IsNullOrEmpty(username))
                    return await Task.FromResult(new ResultItem<User>(null, ErrorStatusType.NullReferenceInput, $"{nameof(username)} is null"));

                var rawData = await _serviceClient.GetUserEndpoint(username);

                if (rawData == null)
                    return await Task.FromResult(new ResultItem<User>(null, ErrorStatusType.NotFound, "Response object is null"));

                return await Task.FromResult(new ResultItem<User>(rawData.ToUser()));
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(ex.Message) && ex.Message.Contains("Not Found"))
                    return await Task.FromResult(new ResultItem<User>(null, ErrorStatusType.NotFound, ex.Message));

                return await Task.FromResult(new ResultItem<User>(null, ErrorStatusType.Exception, ex));

            }

        }

    }
}
