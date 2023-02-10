using System.ComponentModel.DataAnnotations;

namespace PSAch.Core
{
    public class AppUser : BaseModel
    {
        public string Login { get; set; }

        public string? Nickname { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public Gender Gender { get; set; }

        public string Email { get; set; }

        public string? About { get; set; }

        [StringLength(30)]
        public string? City { get; set; }

        [StringLength(30)]
        public string? Country { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Photo? Photo { get; set; }

        public ICollection<Game>? TrackedGames { get; set; }
    }
}
