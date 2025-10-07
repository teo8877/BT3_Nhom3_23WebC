namespace BT3_Nhom3_23WebC.Models
{
    public class AboutViewModel
    {
        public required string Title { get; set; }//required dam bao thuoc tinh duoc gan gia tri truoc khi su dung, tranhs loi runtime
        public required string Description { get; set; }
        public required List<string> Features { get; set; }
        public required string SubTitle { get; set; }
        public required string SubDescription { get; set; }
        public required string Blockquote { get; set; }
    }
}
