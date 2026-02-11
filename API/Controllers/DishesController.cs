using API.Dtos;
using API.Helpers.Commands.CreateDishCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/restaurants/{restaurantId}/dishes")]
    [ApiController]
    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpPost("add")]
        public async Task<ActionResult> AddDish([FromRoute]int restaurantId, [FromBody] CreateDishCommand command)
        {
            command.RestaurantId = restaurantId;
            await mediator.Send(command);
            return Ok();
        }
    }
}