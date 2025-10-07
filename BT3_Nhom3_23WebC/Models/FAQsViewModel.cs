namespace BT3_Nhom3_23WebC.Models
{
    public class FAQsViewModel
    {
        public required string Title { get; set; }
        public List<FAQItem> Items { get; set; } = new List<FAQItem>();
    }
}
