using API.Dtos;
using API.Helpers.Commands.CreateDishCommand;
using API.Models;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperDish : Profile
    {
        public AutoMapperDish()
        {
            CreateMap<CreateDishCommand, Dish>();
            CreateMap<Dish, DishDto>();
        }
    }
}