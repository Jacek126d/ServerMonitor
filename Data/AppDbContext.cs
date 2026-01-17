using Microsoft.EntityFrameworkCore;
using ServerMonitor.Models;

namespace ServerMonitor.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<MonitorTarget> Targets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MonitorTarget>().HasData(
            new MonitorTarget { Id = 1, Name = "YouTube", Url = "https://www.youtube.com", Category = "Social", IsOnline = false },
            new MonitorTarget { Id = 2, Name = "Facebook", Url = "https://www.facebook.com", Category = "Social", IsOnline = false },
            new MonitorTarget { Id = 3, Name = "X", Url = "https://x.com", Category = "Social", IsOnline = false },
            new MonitorTarget { Id = 4, Name = "AWS", Url = "https://aws.amazon.com", Category = "Cloud", IsOnline = false },
            new MonitorTarget { Id = 5, Name = "Azure", Url = "https://azure.microsoft.com", Category = "Cloud", IsOnline = false },
            new MonitorTarget { Id = 6, Name = "Cloudflare", Url = "https://www.cloudflare.com", Category = "Cloud", IsOnline = false },
            new MonitorTarget { Id = 7, Name = "Gov.pl", Url = "https://www.gov.pl", Category = "Government", IsOnline = false }
        );
    }
}