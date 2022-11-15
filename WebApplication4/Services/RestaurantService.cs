using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using WebApplication4.Entities;
using WebApplication4.Models;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using WebApplication4.Exceptions;

namespace WebApplication4.Services
{
    public interface IRestaurantService
    {
        RestaurantDTO GetById(int id);
        IEnumerable<RestaurantDTO> GetAll();
        void Create(CreateRestaurantDTO dto);
        bool Delete(int id);
        void Update(UpdateRestaurantDTO dto, int id);
        EmployeeDTO GetEmpById(int id);
    }

    public class RestaurantService : IRestaurantService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<RestaurantService> _logger;

        public RestaurantService(RestaurantDbContext dbContext,IMapper mapper,ILogger<RestaurantService> logger) { 
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public bool Delete(int id)
        {

            _logger.LogError($"User tried to delete restaurant with id {id} at {DateTime.Now}");
            var restaurant = _dbContext
                .Restaurants
                .FirstOrDefault(x => x.Id == id);
            if (restaurant is null) return false;
            else
            {
                _dbContext.Restaurants.Remove(restaurant);
                _dbContext.SaveChanges();
                return true;
            }
        }

        public void Update(UpdateRestaurantDTO dto,int id)
        {
            var restaurant = _dbContext
                            .Restaurants
                            .FirstOrDefault(r => r.Id == id);
            if (restaurant is null) throw new NotFoundException("Restaurant not found");

            restaurant.Name = dto.Name;
            restaurant.Description = dto.Description;
            restaurant.hasDelivery = dto.hasDelivery;
            _dbContext.SaveChanges();
            
        }

        

        public RestaurantDTO GetById(int id)
        {
            var restaurant = _dbContext.Restaurants
                .Include(r => r.Address)
                .Include(r => r.Dishes)
                .FirstOrDefault(r => r.Id == id);

            if (restaurant == null) return null;

            var result = _mapper.Map<RestaurantDTO>(restaurant);
            return result;
        }

        public IEnumerable<RestaurantDTO> GetAll()
        {
            var restaurants = _dbContext.Restaurants
                .Include(r => r.Address)
                .Include(r => r.Dishes)
                .ToList();

            var restaurantDtos = _mapper.Map<List<RestaurantDTO>>(restaurants);

            return restaurantDtos;
        }

        public void Create(CreateRestaurantDTO dto)
        {
            var restaurant = _mapper.Map<Restaurant>(dto);
            _dbContext.Add(restaurant);
            _dbContext.SaveChanges();
        }

        public EmployeeDTO GetEmpById(int id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(e => e.Id == id);
            if(employee == null)
            {
                return null;
            }
            var employeeDtos = _mapper.Map<EmployeeDTO>(employee);
            return employeeDtos;
        }
    }
}
