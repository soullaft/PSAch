namespace PSAch.Core
{
    public class Photo : BaseModel
    {
        public byte[] Bytes { get; set; }

        public string FileExtensions { get; set; }

        public string Description { get; set; }

        public decimal Size { get; set; }
    }
}
