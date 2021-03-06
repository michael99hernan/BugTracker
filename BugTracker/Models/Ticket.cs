﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace BugTracker.Models
{

    public class StatusUpdates
    {
        public int Id { get; set; }
        public string Desc { get; set; }

    }


    public class Comment
    {
        public int Id { get; set; }

        public int TicketId { get; set; }
        public Ticket TicketNum { get; set; }
        public string MyComment { get; set; }

        public string TrackerUserId { get; set; }
        public TrackerUser Owner { get; set; }
    }
    
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime DateCreated { get; set; }

        public string TrackerUserId { get; set; }
        public TrackerUser UserCreated { get; set; }
        public int StatusUpdatesId { get; set; }
        public StatusUpdates Status { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public string Description { get; set; }

        public List<Comment> Comments { get; set; }

        public static implicit operator Ticket(List<Ticket> v)
        {
            throw new NotImplementedException();
        }
    }
}
