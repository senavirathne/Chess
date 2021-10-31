using System.Collections.Generic;

#nullable disable

namespace Chess.Shared.Models
{
    public partial class User
    {
        

        public long UserId { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Source { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public byte[] DateOfBirth { get; set; }
        public string AboutMe { get; set; }
        public bool Notifications { get; set; }
        public bool DarkTheme { get; set; }
        public byte[] CreatedDate { get; set; }

        
    }
}
