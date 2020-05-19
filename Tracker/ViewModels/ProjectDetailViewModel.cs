using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Models;

namespace Tracker.ViewModels
{
    public class ProjectDetailViewModel
    {
        public Models.Project Project { get; set; }
        public List<Ticket> Ticket { get; set; }


    }
}
