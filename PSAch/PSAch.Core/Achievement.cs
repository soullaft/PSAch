namespace PSAch.Core
{
    public class Achievement : BaseModel
    {
        public string Name { get; set; }

        public string Decription { get; set; }

        public AchievemntTypes AchievemntType { get; set; }

        public bool IsCompleted { get; set; } = false;

        public Game? Game { get; set; }

        public int? GameId { get; set; }

        public Photo? Photo { get; set; }

        public int? PhotoId { get; set; }
    }
}
