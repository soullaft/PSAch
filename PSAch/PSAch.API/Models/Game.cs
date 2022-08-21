namespace PSAch.API.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string PhotoUrl { get; set; }

        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ICollection<Achievement>? Achievements { get; set; }
    }
}
