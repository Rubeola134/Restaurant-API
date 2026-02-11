namespace API.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? KiloCalories { get; set; }
        public Restaurant Restaurant { get; set; } = null!;
        public int RestaurantId { get; set; }
    }
}