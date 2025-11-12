using Microsoft.EntityFrameworkCore;
using NotificationGateway.Model.Entities;

namespace NotificationGateway.Data
{
    public class NotificationDbContext : DbContext
    {
        public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure table name and properties if needed
            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.RequestId).IsUnique();
                entity.HasIndex(e => e.CreatedAt);
                entity.HasIndex(e => e.Status);
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
