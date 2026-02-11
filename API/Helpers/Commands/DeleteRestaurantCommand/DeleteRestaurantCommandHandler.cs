namespace API.Helpers.Commands.DeleteRestaurantCommand
{
    using System.Threading;
    using System.Threading.Tasks;
    using API.Data;
    using API.Data.User;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger, IUserRepository userRepository) : IRequestHandler<DeleteRestaurantCommand, bool>
    {
        async Task<bool> IRequestHandler<DeleteRestaurantCommand, bool>.Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Deleting restaurant with Id {request.Id}.");
            var restaruant = userRepository.GetRestaurantAsync(request.Id).Result;
            if (restaruant is null)
            {
                return false;
            }

            await userRepository.DeleteRestaurantAsync(restaruant);
            return true;
        }
    }
}