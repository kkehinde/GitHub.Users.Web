using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.Users.Model
{
    public class Repo
    {
        public long Id { get; set; }
        public string NodeId { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public bool Private { get; set; }
        public string Description { get; set; }
        public Uri StargazersUrl { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? PushedAt { get; set; }
        public long StargazersCount { get; set; }
        public Uri Url { get; set; }

    }
}
