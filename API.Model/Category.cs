using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Model
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public int CreatedBy { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        

    }
}
