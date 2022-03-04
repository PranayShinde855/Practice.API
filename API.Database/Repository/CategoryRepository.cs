using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Database.Repository
{

    public interface ICategoryRepository : IRepository<Category>
    {
        
    }

    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbModelContext dbModel) : base(dbModel)
        {
        }
    }
}
