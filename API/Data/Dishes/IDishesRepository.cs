using API.Models;

namespace API.Data.Dishes
{
    public interface IDishesRepository
    {
        Task<int> CreateDishAsync(Dish dish);
    }
}