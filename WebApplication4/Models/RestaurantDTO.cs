using System.Collections.Generic;
using WebApplication4.Entities;

namespace WebApplication4.Models
{
    public class RestaurantDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string hasDelivery { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public List<DishDTO> Dishes { get; set; }

    }
}
