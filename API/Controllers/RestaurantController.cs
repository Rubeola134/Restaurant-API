using API.Data;
using API.Dtos;
using API.Helpers.Commands.CreateRestaurant;
using API.Helpers.Commands.DeleteRestaurantCommand;
using API.Helpers.Commands.UpdateRestaurantCommand;
using API.Helpers.Queries.GetAllRestaurants;
using API.Helpers.Queries.GetRestaurantById;
using API.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RestaurantController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetRestaurants")]
        public async Task<ActionResult<List<RestaurantDto>>> GetRestaurants()
        {
            var restaurant = await mediator.Send(new GetAllRestaurantsQuery());
            return Ok(restaurant);
        }

        [HttpGet("GetRestaurant/{id}")]
        public async Task<ActionResult<RestaurantDto>> GetRestaurant(int id)
        {
            var restaruant = await mediator.Send(new GetRestaurantByIdQuery()
            {
                Id = id
            });
            if (restaruant is null)
            {
                return NotFound();
            }
            return Ok(restaruant);
        }
        [HttpDelete("DeleteRestaurant/{id}")]
        public async Task<ActionResult<RestaurantDto>> DeleteRestaurant(int id)
        {
            var isDeleted = await mediator.Send(new DeleteRestaurantCommand(id));
            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPost("AddRestaurant")]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand createRestaurantDto)
        {
            int id = await mediator.Send(createRestaurantDto);
            return Ok(id);
        }

        [HttpPatch("UpdateRestaurant/{id}")]
        
        public async Task<IActionResult> UpdateRestaurant(int id, [FromBody] UpdateRestaurantCommand updateRestaurantDto)
        {
            updateRestaurantDto.Id = id;
            var existingRestaurant = await mediator.Send(updateRestaurantDto);
            if (!existingRestaurant)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}