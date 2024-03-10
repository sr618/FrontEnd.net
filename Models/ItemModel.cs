namespace proj0.Models
{
    public class ItemModel
    {
        public int ItemID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public int CategoryID { get; set; }
        // Nullable int
        public string Name { get; set; }
        public decimal ReservePrice { get; set; }
        public decimal? FinalPrice { get; set; } // Nullable decimal
        public string Photos { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; } // Nullable int
        
        public DateTime? Created { get; set; }  // Nullable DateTime
        public DateTime? Modified { get; set; } // Nullable DateTime
        public bool Sold { get; set; }
        public int userID { get; set; }

    }
}
