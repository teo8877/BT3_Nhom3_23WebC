namespace BT3_Nhom3_23WebC.Models
{
    public class ContactViewModel
    {
        public required string Description { get; set; }
        public List<OfficeContact> Offices { get; set; }
        public ContactFormViewModel ContactForm { get; set; }
    }
}
