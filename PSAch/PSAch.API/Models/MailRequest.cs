namespace PSAch.API.Models
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        
        public string Subject { get; set; }
        
        public string Body { get; set; }
        
        public IList<IFormFile> Attachments { get; set; }
    }
}
