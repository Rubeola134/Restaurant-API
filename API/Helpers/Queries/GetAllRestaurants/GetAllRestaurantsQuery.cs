using API.Dtos;
using MediatR;

namespace API.Helpers.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQuery : IRequest<List<RestaurantDto>>
    {

    }
}