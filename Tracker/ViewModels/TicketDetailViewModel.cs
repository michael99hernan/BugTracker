using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Models;

namespace Tracker.ViewModels
{
    public class TicketDetailViewModel
    {
        public Ticket Tic { get; set; }
        public List<TicketHistory> His { get; set; }
    }
}
