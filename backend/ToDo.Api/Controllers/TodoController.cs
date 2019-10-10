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

        [HttpGet("tasks/{categoryId?}")]
        public ActionResult GetTasks(int? categoryId)
        {
            var categories = _dbContext.Categories.Where(category => 
                category.IsActive && (category.Id == categoryId 
                    || category.ParentId == categoryId));

            var list = _dbContext.Tasks
                .Where(task => categories.Contains(task.Category))
                .OrderByDescending(task => task.StartTime)
                .ToList()
                .Select(task => new 
                {
                    task.Id, task.TaskDate, task.StartTime, task.EndTime, task.DelayTime, task.CategoryId,
                    TaskDay = task.TaskDate.ToString(@"dd.MM.yyyy"),
                    Start = task.StartTime.ToString(@"hh\:mm"),
                    End = task.EndTime.ToString(@"hh\:mm"),
                    Delay = task.DelayTime.ToString(@"hh\:mm"),
                    Period = (task.EndTime - task.StartTime - task.DelayTime).ToString(@"hh\:mm"),
                    Category = task.Category?.Name
                });
            return Ok(list);
        }

        [HttpPost("task")]
        public ActionResult AddTask(Models.TaskModel model)
        {
            var task = new Domain.Task
            {
                Id = model.Id,
                TaskDate = model.TaskDate,
                StartTime = model.StartTime.TimeOfDay,
                EndTime = model.EndTime.TimeOfDay,
                DelayTime = model.DelayTime.TimeOfDay,
                CategoryId = model.CategoryId
            };
            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
