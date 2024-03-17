namespace proj0.Models
{
    public class CartItem
    {
        public int ItemID { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 0;
        public decimal total { get; set; }
    }
}
