namespace PSAch.API.DTOs
{
    public class GameDto
    {
        public int Id { get; set; }

        public string PhotoUrl { get; set; }

        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ICollection<AchievementDto> Achievements { get; set; }
    }
}
