namespace BT3_Nhom3_23WebC.Models
{
    public class ShoppingCartViewModel
    {
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
        public decimal Total { get; set; }
    }
}
