// Connect email API to access.

using System.ComponentModel.DataAnnotations.Schema;

namespace JobTrackr.Models
{
    public class OAuthToken: BaseEntity
    {
    [ForeignKey("UserId")]
    public Guid UserId { get; set; }

    public string AccessToken { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;

    public DateTime ExpiresAt { get; set; }
    
    // What permissions requested from the provider.
    // eg. Gmail.readonly - scope(read onlyl); Outlook.modify - scope(allow edit).
    public string Scope { get; set; } = string.Empty;

    // "Google", "Microsoft"
    public string Provider { get; set; } = string.Empty;

    public bool IsRevoked { get; set; } = false;

    public DateTime? RevokedAt { get; set; }

    public User User { get; set; } = null!;

    [NotMapped]
    public bool IsExpired => DateTime.UtcNow >= ExpiresAt.AddMinutes(-5);
        
    }
}