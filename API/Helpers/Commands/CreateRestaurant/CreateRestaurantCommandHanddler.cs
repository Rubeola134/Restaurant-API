using API.Data;
using API.Data.User;
using API.Dtos;
using API.Models;
using AutoMapper;
using MediatR;

namespace API.Helpers.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHanddler(ILogger<CreateRestaurantCommandHanddler> logger, IMapper mapper, 
    IUserRepository userRepository) : IRequestHandler<CreateRestaurantCommand, int>
    {
        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Creating Restaurant");
            var restaurant = mapper.Map<Restaurant>(request);
            var id = await userRepository.CreateRestaurantAsync(restaurant);
            return id;
        }
    }
}