namespace PSAch.API.Models
{
    public class Achievement
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Decription { get; set; }

        public AchievemntTypes AchievemntType { get; set; }

        public bool IsCompleted { get; set; }

        public Game Game { get; set; }

        public int GameId { get; set; }
    }

    public enum AchievemntTypes : int
    {
        Bronze = 0,
        Silver = 1,
        Gold = 2,
        Platinum = 3,
    }
}
