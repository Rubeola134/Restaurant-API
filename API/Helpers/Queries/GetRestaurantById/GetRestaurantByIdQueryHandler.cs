using API.Data;
using API.Data.User;
using API.Dtos;
using AutoMapper;
using MediatR;

namespace API.Helpers.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQueryHandler(ILogger<GetRestaurantByIdQueryHandler> logger, IMapper mapper, 
    IUserRepository userRepository) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto?>
    {
        public async Task<RestaurantDto?> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Fetching restaurant with Id {request.Id}.");
            var restaurant = await userRepository.GetRestaurantAsync(request.Id);
            var restaurantDtos = mapper.Map<RestaurantDto?>(restaurant);
            return restaurantDtos;
        }
    }
}