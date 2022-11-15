using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Entities;
using WebApplication4.Models;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
       
        private readonly IRestaurantService _service;

        public RestaurantController(IRestaurantService service)
        {
          
            _service = service;
        }

        [HttpDelete("{id}")]


        public ActionResult Delete([FromRoute] int id)
        {

            var isDeleted = _service.Delete(id);
            if (!isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut("{id}")]

        public ActionResult Update([FromBody]UpdateRestaurantDTO dto, [FromRoute] int id)
        {

            _service.Update(dto,id);

            return Ok();
        } 


        [HttpPost]

        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _service.Create(dto);

            return  NoContent();

        }

        [HttpGet]

        public ActionResult<IEnumerable<Restaurant>> GetaLL()
        {
            return Ok(_service.GetAll());

        }

        [HttpGet("{id}")]

        public ActionResult<Restaurant> Get([FromRoute] int id)
        {
          
            return Ok(_service.GetById(id));
        }
        [HttpGet("x{id}")]
        public ActionResult<EmployeeDTO> GetEmp([FromRoute] int id)
        {
            return Ok(_service.GetEmpById(id));
        }

    }
}                                   
