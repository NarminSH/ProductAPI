using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Dtos.Products;
using ProductAPI.Models;
using ProductAPI.Services.Interfaces;
using ProductAPI.Services.Interfaces.ProductService;
using ProductAPI.Utilities;
using ProductAPI.Utilities.Exceptions;

namespace ProductAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper,
            IRestaurantService restaurantService)
        {
            _productService = productService;
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ResponseMessage> Get() 
        {
            return await _productService.GetAll();
        }

        [HttpGet("{id}")]
        public Product GetById(int id )
        {
            Product result=_productService.GetById(id);
            return result;
        }

        [HttpPost]
        public async Task<ResponseMessage> Add(CreateProductDto createProductDto)
        {
            Restaurant restaurant = _restaurantService.GetById(createProductDto.RestaurantId);
            if (restaurant == null)
            {
                return new ResponseMessage()
                {
                    Message = "Restaurant Id does not exist",
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            Product product = _mapper.Map<Product>(createProductDto);
            return await _productService.Add(product);

        }

        [HttpPut]
        public async Task<ResponseMessage> Update([FromBody]  UpdateProductDto updateProductDto)
        {
            Restaurant restaurant = _restaurantService.GetById(updateProductDto.RestaurantId);
            if (restaurant == null)
            {
                return new ResponseMessage()
                {
                    Message = "Restaurant Id does not exist",
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            Product product = _mapper.Map<Product>(updateProductDto);
            return await _productService.Update(product);
        }



    }
}
