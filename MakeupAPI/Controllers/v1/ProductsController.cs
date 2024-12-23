using MakeupAPI.Interface;
using MakeupAPI.Services.ProductsServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MakeupAPI.Controllers.v1
{
    [Authorize]
    [Route("api/v{version:apiVersion}/products")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsInterface _productsInterface;

        public ProductsController(IProductsInterface productsInterface)
        {
            _productsInterface = productsInterface;
        }
   
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productsInterface.GetProductsAsync();
            return Ok(products);  
        }


        }
}
