using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Database.IRepository
{
   public  interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
            
        Task GetId(int Id);

        Task<Product> AddProduct(Product product);
    }
}
