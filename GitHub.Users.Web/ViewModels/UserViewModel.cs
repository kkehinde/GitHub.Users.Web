using Newtonsoft.Json;
using System;

namespace GitHub.Users.Web.ViewModels
{
    public partial class UserViewModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar_url")]
        public Uri AvatarUrl { get; set; }

        [JsonProperty("repos_url")]
        public Uri ReposUrl { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

    }



}
