using AutoMapper;
using WebApplication4.Entities;
using WebApplication4.Models;

namespace WebApplication4
{
    public class RestaurantMappingProfile: Profile
    {
        public RestaurantMappingProfile()
        {
            CreateMap<Restaurant, RestaurantDTO>()
                .ForMember(m => m.City, C => C.MapFrom(s => s.Address.City))
                .ForMember(m => m.Street, C => C.MapFrom(s => s.Address.Street))
                .ForMember(m => m.PostalCode, C => C.MapFrom(s => s.Address.PostalCode));

            CreateMap<Dish, DishDTO>();

            CreateMap<CreateRestaurantDTO, Restaurant>()
                .ForMember(r => r.Address,
                    c => c.MapFrom(dto =>
                        new Address(){ City = dto.City, Street = dto.Street, PostalCode = dto.PostalCode, }));

            CreateMap<Employee, EmployeeDTO>();

            CreateMap<CreateDishDTO ,Dish>();

        }
        
        

    }
}
