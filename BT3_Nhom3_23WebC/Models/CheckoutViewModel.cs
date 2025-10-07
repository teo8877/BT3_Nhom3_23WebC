namespace BT2_Nhom3_23WebC.Models
{
    public class CheckoutViewModel
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool TermsAccepted { get; set; }
        public decimal Total { get; set; }
    }
}
