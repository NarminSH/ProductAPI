using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Services.Interfaces.ProductService;
using ProductAPI.Utilities;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService= productService;
        }

        [HttpGet]
        public async Task<ResponseMessage> Get() 
        {
            return await _productService.GetAll();
        }

       
       
    }
}
