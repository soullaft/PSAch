using System.ComponentModel.DataAnnotations;

namespace PSAch.API.DTOs
{
    public sealed class GameDto
    {
        public int Id { get; set; }

        public string PhotoUrl { get; set; }

        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Range(1, 10)]
        public int Difficulty { get; set; }

        public ICollection<AchievementDto>? Achievements { get; set; }
    }
}
