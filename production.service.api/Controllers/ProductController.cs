
using Microsoft.AspNetCore.Mvc;
using production.service.api.Helpers;
using production.service.api.Interfaces;
using production.service.api.Models;
using production.service.api.Models.Dto;

namespace production.service.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
                _productService = productService;
        }



        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet("{productId}")]
        public ActionResult<Product> GetById(Guid productId)
        {
            var product =_productService.GetById(productId);
            if (product == null)
                return NotFound();

            return Ok(product);
        }


        [HttpPost]
        public ActionResult Create([FromBody]ProductDto productDto)
        {
            var product = MapperHelper.Map<Product,ProductDto>(new Product(), productDto);
            _productService.Create(product);
            return Ok(new { message = "Product created successfully." });
        }

        [HttpPut("{productId}")]
        public IActionResult Update(Guid productId, [FromBody] ProductDto productDto)
        {
            var product = MapperHelper.Map<Product, ProductDto>(new Product(), productDto);

            var success = _productService.Update(product, productId);

            if (!success)
                return NotFound(new { message = "The product does not exist." });

            return NoContent(); 
        }

        [HttpDelete("{productId}")]
        public IActionResult Delete(Guid productId)
        {
            var existing = _productService.GetById(productId);
            if (existing == null)
                return NotFound(new { message = "The product does not exist" });

            _productService.Delete(productId);
            return NoContent(); 
        }
    }
}
