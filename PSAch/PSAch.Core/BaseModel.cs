﻿namespace PSAch.Core
{
    public class BaseModel
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
