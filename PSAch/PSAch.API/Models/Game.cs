namespace PSAch.API.Models
{
    public class Game : BaseModel
    {
        public string PhotoUrl { get; set; }

        public string Name { get; set; }

        public Photo? Photo { get; set; }

        public int? PhotoId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ICollection<Achievement>? Achievements { get; set; }
    }
}
