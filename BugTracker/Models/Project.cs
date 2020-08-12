using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class Project
    {
#nullable enable
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        public DateTime DateCreated { get; set; }

#nullable disable
        public string UserId { get; set; }
        public TrackerUser Owner { get; set; }

        public ICollection<UserProject> UserProject { get; set; }
    }
}
