using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.Users.Model.Extensions
{
   public static class UsersExtension
    {
        public static List<User>  ToUsers(this List<RawUserData> rawUsers)
        {
            if (rawUsers == null || rawUsers.Count == 0)
                return new List<User>();

            var results = rawUsers.Select(c => c.ToUser())?.ToList();

            return results;
        }

        public static User ToUser(this RawUserData rawUser)
        {
            if (rawUser == null)
                return null;

            User basicUser = new User
            {
                AvatarUrl = rawUser.AvatarUrl,
                Location = rawUser.Location,
                Name = rawUser.Name,
                ReposUrl = rawUser.ReposUrl,
                 Id = rawUser.Id
            };

            return basicUser;

        }


    }
}
