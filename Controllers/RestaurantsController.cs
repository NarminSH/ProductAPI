using Microsoft.AspNetCore.Mvc;
using ProductAPI.Dtos;
using ProductAPI.Models;
using ProductAPI.Services.Interfaces;
using ProductAPI.Utilities;

namespace ProductAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantsController(IRestaurantService restaurant)
        {
            _restaurantService = restaurant;
        }

        [HttpGet]
        public async Task<ResponseMessage> Get()
        {
            return await _restaurantService.GetAll();
        }

       /* [HttpPost]
        public ResponseMessage Create(CreateRestaurantDto createDto)
        {

            _restaurantService.Add

        }*/
    }
}