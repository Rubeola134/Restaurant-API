using API.Data;
using API.Data.User;
using API.Dtos;
using AutoMapper;
using MediatR;

namespace API.Helpers.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQueryHandler> logger, IMapper mapper, 
    IUserRepository userRepository) : IRequestHandler<GetAllRestaurantsQuery, List<RestaurantDto>>
    {
        public async Task<List<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Fetching all restaurants. {@Restaurant}", request);
            var restaurants = await userRepository.GetAllRestaurantsAsync();
            var restaurantDtos = mapper.Map<List<RestaurantDto>>(restaurants);
            return restaurantDtos;
        }
    }
}