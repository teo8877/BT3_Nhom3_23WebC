namespace BT3_Nhom3_23WebC.Models
{
    public class FAQItem
    {
        public required string Question { get; set; }
        public List<string> Answers { get; set; } = new List<string>();
    }
}
