using AutoMapper;
using System.Linq;
using WebApplication4.Entities;
using WebApplication4.Exceptions;
using WebApplication4.Models;

namespace WebApplication4.Services
{
    public interface IDishService
    {
        int Create(int id, CreateDishDTO dto);
        DishDTO GetById(int resId, int dishId);
    }


    public class DishService : IDishService
    {
        private RestaurantDbContext _context;
        private IMapper _mapper;

        public DishService(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(int id, CreateDishDTO dto)
        {
            var restaurant = _context.Restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant is null)
            {
                throw new NotFoundException("Restaurant not found");
            }
            var dishEntity = _mapper.Map<Dish>(dto);

            dishEntity.RestaurantId = id;
            restaurant.Dishes.Add(dishEntity);
            _context.SaveChanges();
            return dishEntity.Id;

        }

        public DishDTO GetById(int restaurantID, int dishID)
        {
            var restaurant = _context.Restaurants.FirstOrDefault(r => r.Id == restaurantID);
            if (restaurant is null)
            {
                throw new NotFoundException("Restaurant not found");
            }
            var dish = _context.Dishes.FirstOrDefault(d => d.Id == dishID);
            if (dish is null || dish.RestaurantId!=restaurantID) 
            {
                throw new NotFoundException("Dish not founded");
            }
            var dishDto = _mapper.Map<DishDTO>(dish);
            return dishDto;
        }
    }
}
