using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Domain;

namespace ToDo.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private AppDbContext _dbContext;
        public TodoController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("categories")]
        public ActionResult<List<Category>> GetCategories()
        {
            return _dbContext.Categories
                .Where(ctg => ctg.IsActive)
                .OrderBy(x => x.Id)
                .ToList();
        }

        // GET api/values/5
        [HttpGet("categories/{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null) 
                return NotFound();
            else
                return Ok(category);
        }

        [HttpPost("category")]
        public ActionResult AddCategory([FromBody] Category category)
        {
            category.IsActive = true;
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();

            return Ok(category);
        }

        [HttpPut("category/{id}")]
        public ActionResult UpdateCategory(int id, [FromBody] Category _category)
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null) return NotFound();
            
            category.Name = _category.Name;
            category.ParentId = _category.ParentId;
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("category/{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null) return NotFound();

            category.IsActive = false;
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
