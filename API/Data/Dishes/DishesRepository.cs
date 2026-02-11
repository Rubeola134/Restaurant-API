using API.Models;

namespace API.Data.Dishes
{
    public class DishesRepository(DataContextEF ef) : IDishesRepository
    {

        public async Task<int> CreateDishAsync(Dish dish)
        {
            ef.Dishes.Add(dish);
            await ef.SaveChangesAsync();
            return dish.Id;
        }

    }
}