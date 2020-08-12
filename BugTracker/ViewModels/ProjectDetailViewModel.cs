using BugTracker.Models;
using System.Collections.Generic;

namespace Tracker.ViewModels
{
    public class ProjectDetailViewModel
    {
        public Project Project { get; set; }
        public List<Ticket> Ticket { get; set; }


    }
}
