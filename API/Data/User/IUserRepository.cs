using API.Dtos;
using API.Models;

namespace API.Data.User
{
    public interface IUserRepository
    {
        Task<List<Restaurant>> GetAllRestaurantsAsync();
        Task<Restaurant?> GetRestaurantAsync(int id);
        Task<int> CreateRestaurantAsync(Restaurant restaurant);
        Task DeleteRestaurantAsync(Restaurant restaurant);
        Task UpdateRestaurantAsync(Restaurant restaurant);
    }
}