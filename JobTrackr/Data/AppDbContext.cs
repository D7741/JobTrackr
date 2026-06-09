using Microsoft.EntityFrameworkCore;
using JobTrackr.Models;

namespace JobTrackr.Data
{
    public class AppDbContext : DbContext
    {
        // DbcontextOptions - package installed
        // The AppDbContext receive DbContextOption structure parameter from EF core
        // Then transfer the "option" back to parent class to structure the DB.
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<JobApplication> JobApplications => Set<JobApplication>();
        public DbSet<OAuthToken> OAuthTokens => Set<OAuthToken>();
        public DbSet<ParsedEmail> ParsedEmails => Set<ParsedEmail>();
        public DbSet<EmailSyncLog> EmailSyncLogs => Set<EmailSyncLog>();


        // Normally can just state the relation that no clear by models here.
        // Such as One to One relations.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                // One User has one OAuthToken.
                .HasOne(u => u.OAuthToken)
                // WithOne  - also one Token has one User.
                // They are one to one relation.
                .WithOne(t => t.User)
                .HasForeignKey<OAuthToken>(t => t.UserId);

            modelBuilder.Entity<JobApplication>()
                .HasIndex(j => j.UserId);

            modelBuilder.Entity<EmailSyncLog>()
                .HasIndex(e => e.UserId);
            modelBuilder.Entity<EmailSyncLog>()
                .HasIndex(e => e.StartedAt);
            modelBuilder.Entity<EmailSyncLog>()
                .HasIndex(e => new { e.UserId, e.Status });

            modelBuilder.Entity<ParsedEmail>()
                .HasIndex(p => p.EmailMessageId)
                .IsUnique();
        }
    }
}
