using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    [Route("api/restaurant/{restaurantId}/dish")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private IDishService _service;

      
        public DishController(IDishService service)
        {
            _service = service;
        }
        [HttpPost]
        public ActionResult Post([FromRoute] int restaurantId, [FromBody] CreateDishDTO dto)
        {
            var newDishId = _service.Create(restaurantId, dto);

            return Created($"api/restaurant/{restaurantId}/dish/{newDishId}", null);
        }
        [HttpGet("{dishId")]
        public ActionResult<DishDTO> GetById([FromRoute]int restaurantId, [FromRoute] int dishId )
        {
            DishDTO dish = _service.GetById(restaurantId, dishId);
            return dish;
        }

    }
}
