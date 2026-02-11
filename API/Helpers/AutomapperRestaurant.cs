using API.Dtos;
using API.Helpers.Commands.CreateRestaurant;
using API.Helpers.Commands.UpdateRestaurantCommand;
using API.Models;
using AutoMapper;

namespace API.Helpers
{
    public class AutomapperRestaurant : Profile
    {
        public AutomapperRestaurant()
        {
            CreateMap<UpdateRestaurantCommand, Restaurant>();
            CreateMap<Restaurant, RestaurantDto>()
                      .ForMember(d => d.City,
                          opt => opt.MapFrom(src => src.Address != null ? src.Address.City : ""))
                      .ForMember(d => d.Street,
                          opt => opt.MapFrom(src => src.Address != null ? src.Address.Street : ""))
                      .ForMember(d => d.PostalCode,
                          opt => opt.MapFrom(src => src.Address != null ? src.Address.Street : ""))
                        .ForMember(d => d.Dishes, opt => opt.MapFrom(src => src.Dishes));
            CreateMap<CreateRestaurantCommand, Restaurant>()
                .ForMember(cr => cr.Address, opt => opt.MapFrom(
                    src => new Address
                    {
                        City = src.City!,
                        PostalCode = src.PostalCode!,
                        Street = src.Street!
                    }
                )).ForMember(d => d.Dishes, opt => opt.Ignore());
        }
    }
}