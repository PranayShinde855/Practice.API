using API.Database.IRepository;
using API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Database.Repository
{
    public class ProductRepository : IProductRepository
    {
        protected DbModelContext _dbModelContext;

        public ProductRepository(DbModelContext dbModelContext)
        {
            _dbModelContext = dbModelContext;
        }

        public async Task<Product> AddProduct(Product product)
        {
            _dbModelContext.products.Add(product);
           await _dbModelContext.SaveChangesAsync();
            return product;
        }

        public async Task GetId(int Id)
        {
            var searchId = await _dbModelContext.products.FindAsync(Id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _dbModelContext.products.ToListAsync();
        }
    }
}
