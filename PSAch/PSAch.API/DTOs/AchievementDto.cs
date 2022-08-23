﻿using PSAch.API.Models;

namespace PSAch.API.DTOs
{
    public class AchievementDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Decription { get; set; }

        public AchievemntTypes AchievemntType { get; set; }

        public bool IsCompleted { get; set; }
    }
}
