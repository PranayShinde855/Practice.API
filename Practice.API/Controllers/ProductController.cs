using API.Database.IRepository;
using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;


        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository; 
        }

        [Route("GetProducts")]
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productRepository.GetProducts();
        }

        [Route("AddProduct")]
        [HttpPost]
        public async Task<Product> AddProduct (Product product)
        {
            return await _productRepository.AddProduct(product);
        }

        [Route("GetProduct/{Id}")]
        [HttpGet]
        public async Task GetId(int Id)
        {
          await _productRepository.GetId(Id);
        }
    }
}
