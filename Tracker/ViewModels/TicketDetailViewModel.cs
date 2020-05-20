using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Models;

namespace Tracker.ViewModels
{
    public class TicketDetailViewModel
    {
        public TicketDetailViewModel()
        {
            currComment = new Comment();
        }
        public Ticket Tic { get; set; }
        public List<TicketHistory> His { get; set; }

        public List<Comment> Com { get; set; }
        public Comment currComment { get; set; }
    }
}
