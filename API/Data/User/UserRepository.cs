
using API.Dtos;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.User
{
    public class UserRepository(DataContextEF ef) : IUserRepository
    {
        public async Task<List<Restaurant>> GetAllRestaurantsAsync()
        {
            return await ef.Restaurants.Include(r => r.Dishes).ToListAsync();
        }

        public async Task<Restaurant?> GetRestaurantAsync(int id)
        {
            return await ef.Restaurants
    .SingleOrDefaultAsync(r => r.Id == id);
        }

        public async Task<int> CreateRestaurantAsync(Restaurant restaurant)
        {
            ef.Restaurants.Add(restaurant);
            await ef.SaveChangesAsync();
            return restaurant.Id;
        }

        public async Task DeleteRestaurantAsync(Restaurant restaurant)
        {
            ef.Restaurants.Remove(restaurant);
            await ef.SaveChangesAsync();
        }

        public async Task UpdateRestaurantAsync(Restaurant restaurant)
        {
            ef.Restaurants.Update(restaurant);
            await ef.SaveChangesAsync();
        }

    }
}