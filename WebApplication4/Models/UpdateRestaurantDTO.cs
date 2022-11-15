using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class UpdateRestaurantDTO
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public string Description { get; set; } 
        public string hasDelivery { get; set; }
    }
}
