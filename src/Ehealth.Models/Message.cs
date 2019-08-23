namespace Ehealth.Models
{
    public class Message
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
