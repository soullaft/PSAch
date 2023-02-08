using PSAch.API.Models;
using System.ComponentModel.DataAnnotations;

namespace PSAch.API.DTOs
{
    public sealed class RegisterUserDto
    {
        [Required]
        public string? Login { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string? Password { get; set; }

        public Gender Gender { get; set; }

        public string? Email { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
