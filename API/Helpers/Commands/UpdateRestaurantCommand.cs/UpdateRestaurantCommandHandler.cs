using API.Data;
using API.Data.User;
using AutoMapper;
using MediatR;

namespace API.Helpers.Commands.UpdateRestaurantCommand
{
    public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger, IUserRepository userRepository, IMapper mapper) : IRequestHandler<UpdateRestaurantCommand, bool>
    {
        public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Updating restaurant with Id {request.Id}.");
            var restaurant = await userRepository.GetRestaurantAsync(request.Id);
            if (restaurant is null)
            {
                return false;
            }
            mapper.Map(request, restaurant);
            // restaurant.Name = request.Name;
            // restaurant.Description = request.Description;
            // restaurant.HasDelivery = request.HasDelivery;
            // restaurant.Category = request.Category;
            await userRepository.UpdateRestaurantAsync(restaurant);
            return true;
        }
    }
}