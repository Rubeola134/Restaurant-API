using API.Dtos;
using MediatR;

namespace API.Helpers.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQuery : IRequest<RestaurantDto?>
    {
        public int Id { get; set; }
    }
}