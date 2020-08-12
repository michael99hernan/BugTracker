
using BugTracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BugTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
           public DbSet<Project> Projects { get; set; }
           public DbSet<UserProject> UserProjects { get; set; }
           public DbSet<Ticket> Ticket { get; set; }
           public DbSet<TicketHistory> TicketHistories{ get; set; }
           public DbSet<Comment> Comments { get; set; }
    }
}
