
namespace Client.Domain.Messages
{
    public class JobCreatedMessage
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Precision { get; set; }
    }
}
