using API.Model;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.API.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        [Produces(typeof(IEnumerable<Product>))]
        public async Task<IActionResult> GetAllProduct ()
        {
            IEnumerable<Product> _product = (IEnumerable<Product>)await _productServices.GetAllProducts();
            return Ok(_product);
        }

        [HttpPost]
        [Route("AddProducts")]
        [Produces(typeof(Product))]
        public IActionResult AddProduct(Product product)
        {
            Product _product = _productServices.AddProduct(product);
            return Ok(_product);
        }

        [HttpPut()]
        [Route("UpdateProduct/{Id}")]
        [Produces(typeof(Product))]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            Product product1 = await _productServices.UpdateProduct(product);
            return Ok(product1);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [Produces(typeof(bool))]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            bool isDeleted = await _productServices.DeleteProduct(id);
            return Ok(isDeleted);
        }
    }
}
