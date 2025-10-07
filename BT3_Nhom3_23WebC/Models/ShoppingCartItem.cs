namespace BT3_Nhom3_23WebC.Models
{
    public class ShoppingCartItem
    {
        public required string Name { get; set; }
        public required string ImageUrl { get; set; }
        public required string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
