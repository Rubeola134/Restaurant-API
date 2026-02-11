using MediatR;

namespace API.Helpers.Commands.DeleteRestaurantCommand
{
    public class DeleteRestaurantCommand(int id) : IRequest<bool>
    {
        public int Id { get;} = id;
    }
}