using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Database.Repository;
using API.Model;
using Nest;

namespace API.Services
{
    public interface IProductServices
    {
        Product AddProduct(Product product);

        Task<IEnumerable> GetAllProducts();

        Task<Product> GetProductById(int Id);

        Task<bool> DeleteProduct(int Id);

        Task<Product> UpdateProduct(Product product);
    }

    public class ProductServices : IProductServices
    {
        private IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product AddProduct(Product product)
        {
            _productRepository.Add(product);
            return product;
        }

        public async Task<bool> DeleteProduct(int Id)
        {
            Product productId = await _productRepository.GetById(Id);
            if (productId != null)
            {
                _productRepository.Delete(productId);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable> GetAllProducts()
        {
           return await _productRepository.Get();
        }

        public async Task<Product> GetProductById(int Id)
        {
            return await _productRepository.GetById(Id);
        }

        public async Task<Product> UpdateProduct(int Id)
        {
            var getId = await _productRepository.GetById(Id);
            if (getId != null)
            {
                _productRepository.Update(getId);
                return getId;
            }
            return getId;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var getId = await _productRepository.GetById(product.Id);
            if (getId != null)
            {
                _productRepository.Update(getId);
                return getId;
            }
            return getId;
        }
    }
}

