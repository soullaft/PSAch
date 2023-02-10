namespace PSAch.Core
{
    public class MailRequest<T>
    {
        public string ToEmail { get; set; }
        
        public string Subject { get; set; }
        
        public string Body { get; set; }
        
        public IList<T> Attachments { get; set; }
    }
}
