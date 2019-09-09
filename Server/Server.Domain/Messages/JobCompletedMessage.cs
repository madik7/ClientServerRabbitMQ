namespace Server.Domain.Messages
{
    public class JobCompletedMessage
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Precision { get; set; }
        public string Result { get; set; }
    }
}
