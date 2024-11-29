using API_Project._Repository;
using API_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepository _productRepository;
        public ProductController(IProductRepository prdrepo)
        {
            this._productRepository = prdrepo;
        }
        [HttpGet]
        public IActionResult DisplayALl()
        {
            List<Product> products = 
                _productRepository.GetAll();
            return Ok(products);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult DisplayById(int id)
        {
            Product product =
                _productRepository.GetById(id);
            return Ok(product);
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }
            try
            {
                _productRepository.Add(product);
                return CreatedAtAction("DisplayById", new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut]
        public IActionResult Edit(int id,Product productFromRequset)
        {
            Product productfromDB= _productRepository.GetById(id);
            
           if (productfromDB is not null)
           {
                productfromDB.Name = productFromRequset.Name;
                productfromDB.Price = productFromRequset.Price;
                productfromDB.Description = productFromRequset.Description;
                productfromDB.CategoryId = productFromRequset.CategoryId;
                _productRepository.Save();
                return NoContent();

           }
           else
           {
              return NotFound();
           }

        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            _productRepository.Delete(id);
            return NoContent();
        }


    }
}
