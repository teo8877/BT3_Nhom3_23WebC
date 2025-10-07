namespace BT3_Nhom3_23WebC.Models
{
    public class RequestFileLogModel
    {
        public DateTime Timestamp { get; set; }
        public required string Level { get; set; }
        public required string Message { get; set; } 
        public required string Source { get; set; }
        public required string Exception { get; set; }
    }
}
