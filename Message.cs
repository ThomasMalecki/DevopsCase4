namespace DevopsCase4
{
    public class Message
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int? FromId { get; set; }
        public int? ToId { get; set; }
        public string? Timestamp { get; set; }
    }
}