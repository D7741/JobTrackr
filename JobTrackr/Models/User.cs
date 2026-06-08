namespace JobTrackr.Models
{
    public class User: BaseEntity
    {
        public string Email {get; set;} = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string FullName {get; set;} = string.Empty;
        
        // When load User, load the API info at the same time(will be use).
        public OAuthToken? OAuthToken {get; set;}

        // IEnumerable - read only, EF Core direction must use ICollection.
        public ICollection<JobApplication> JobApplications{get; set;} = [];

        public ICollection<EmailSyncLog> EmailSyncLogs{get; set;} = [];
    }
}