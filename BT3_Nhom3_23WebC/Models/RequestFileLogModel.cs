namespace BT3_Nhom3_23WebC.Models
{
    public class RequestFileLogModel
    {
        public DateTime Timestamp { get; set; }
        public string Level { get; set; }
        public string Message { get; set; } 
        public string Source { get; set; }
        public string Exception { get; set; }
    }
}
