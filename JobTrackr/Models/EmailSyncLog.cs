using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTrackr.Models
{
    public enum SyncStatus { Running, Completed, Failed }

    public class EmailSyncLog
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public SyncStatus Status { get; set; } = SyncStatus.Running;

        public int EmailsScanned { get; set; }

        public int ApplicationsUpdated { get; set; }

        public string? ErrorMessage { get; set; }

        public DateTime StartedAt { get; set; } = DateTime.UtcNow;

        public DateTime? FinishedAt { get; set; }

        public User User { get; set; } = null!;
    }
}