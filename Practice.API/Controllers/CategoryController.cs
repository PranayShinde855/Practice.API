using API.Model;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<IEnumerable> GetAllCategories()
        {
            return await _categoryServices.GetAllCatgeories();
        }

        [HttpGet]
        [Route("GetById")]
        public Task<Category> GetCategoryById(int Id)
        {
            return _categoryServices.GetCategoryId(Id);
        }

        [HttpPut()]
        [Route("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            var result = await _categoryServices.UpdateCategroy(category);
            return Ok(result);
        }

        [HttpPost]
        [Route("AddCategory")]
        public IActionResult AddCategory(Category category)
        {
            Category _category = _categoryServices.AddCategory(category);
            return Ok(_category);
        }
    }
}
