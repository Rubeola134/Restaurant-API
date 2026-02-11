using API.Data.Dishes;
using API.Data.User;
using API.Dtos;
using API.Models;
using AutoMapper;
using MediatR;



namespace API.Helpers.Commands.CreateDishCommand
{
    public class CreateDishCommandHandler(ILogger<CreateDishCommandHandler> logger, IUserRepository userRepository, IDishesRepository dishesRepository,
     IMapper mapper) : IRequestHandler<CreateDishCommand>
    {
        public async Task Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Creating Dish");
            var restaruant = await userRepository.GetRestaurantAsync(request.RestaurantId);
            if (restaruant == null)
            {
                logger.LogError($"Restaurant with id {request.RestaurantId} not found");
                throw new Exception($"Restaurant with id {request.RestaurantId} not found");
            }

            var dish = mapper.Map<Dish>(request);

            await dishesRepository.CreateDishAsync(dish);
        }
    }
}