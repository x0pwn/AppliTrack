using Microsoft.EntityFrameworkCore;
using AppliTrack.Models;

namespace AppliTrack.Data
{
    public class JobTrackerContext : DbContext
    {
        public JobTrackerContext(DbContextOptions<JobTrackerContext> options)
            : base(options) { }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Note> Notes        { get; set; }
    }
}
