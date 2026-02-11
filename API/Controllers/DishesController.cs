using API.Dtos;
using API.Helpers.Commands.CreateDishCommand;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;


namespace API.Controllers
{
    [Route("api/restaurants/{restaurantId}/[controller]")]
    [ApiController]
    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpPost ("add")]
        public async Task<ActionResult> AddDish([FromRoute]int restaurantId, [FromBody] CreateDishCommand command)
        {
            command.RestaurantId = restaurantId;
            await mediator.Send(command);
            return Ok();
        }

        // [HttpGet("dishes")]
        // public async Task<ActionResult<List<DishDto>>> GetDishes()
        // {

        // }
    }
}