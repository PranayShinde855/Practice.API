using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Model;

namespace API.Database.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
    }
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbModelContext dbModelContext): base(dbModelContext)
        {

        }
    }
}
