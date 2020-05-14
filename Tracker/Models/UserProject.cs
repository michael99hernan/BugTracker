﻿using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Models
{
    public class UserProject
    {
        public int Id { get; set; }
        public int TrackerUserId { get; set; }
        public TrackerUser User { get; set; }

        public int ProductId { get; set; }
        public Project Project { get; set; }
    }
}
