using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JobTrackr.DTOs.V1
{
    public class RegisterRequest
    {
        [Required, EmailAddress]
        public string Email {get; set;} = string.Empty;

        [Required]
        public string FullName {get; set;} = string.Empty;

        [Required, MinLength(8)]
        public string Password {get; set;} = string.Empty;

        // Constructor Function - receive data from outer
        // No Return; Auto RUN; Same name with class
        public RegisterRequest(string email, string password, string fullName)
        {
            // Cover the inital data by the data received.
            Email = email;
            Password = password;
            FullName = fullName;
        }

    }
}