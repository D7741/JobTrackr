using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Record the email that been ai tracked.
namespace JobTrackr.Models
{
    public class ParsedEmail
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey("JobApplication")]
        public Guid JobApplicationId { get; set; }

        public string EmailMessageId { get; set; } = string.Empty;
        
        public string Subject { get; set; } = string.Empty;

        public string FromAddress { get; set; } = string.Empty;

        public ApplicationStatus AiStatus { get; set; } = ApplicationStatus.Unknown;

        public double AiConfidence { get; set; }

        public string RawSnippet { get; set; } = string.Empty;

        public DateTime ReceivedAt { get; set; }

        public DateTime ParsedAt { get; set; } = DateTime.UtcNow;

        public JobApplication JobApplication { get; set; } = null!;
    }
}