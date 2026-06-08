using System.ComponentModel.DataAnnotations.Schema;

namespace JobTrackr.Models
{
    public enum ApplicationStatus
    {
        Applied,
        InReview,
        InterviewScheduled,
        InterviewCompleted,
        OfferReceived,
        Rejected,
        Withdrawn,
        Unknown
    }
    public class JobApplication: BaseEntity
    {
        // Convention: [NavigationPropertyName] + Id.
        [ForeignKey("User")]
        public Guid UserId {get; set;}

        public string CompanyName {get; set;} = string.Empty;

        public string RoleTitle {get; set;} = string.Empty;

        public string Platform { get; set; } = string.Empty;

        public ApplicationStatus Status {get; set;}

        public string? SourceUrl {get; set;}

        // Difference between BaseEntity by AppliedAt state the time when user applied
        // And BaseEntity attribute CreateAt state the time when user add the case into JobTrackr.
        public DateTime AppliedAt {get; set;} = DateTime.UtcNow;

        public DateTime LastActivityAt {get; set;} = DateTime.UtcNow;


        // AI tracking need.
        // AiParsed is a flag that tracks whether the AI has ever processed this application.
        // Human set - False; Ai set - True.
        public bool AiParsed {get; set;} = false;

        public bool UserOverridden { get; set;} = false;

        public User User {get; set;} = null!;

        public ICollection<ParsedEmail> ParsedEmails {get; set;} = [];
 



    }
}