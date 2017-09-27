using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LearningCore.Services;
using LearningCore.Services.ServiceModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearningCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoCategoryServiceController : BaseController
    {
        private readonly ITodoLabelService todoCategoryService;

        public TodoCategoryServiceController(ITodoLabelService todoCategoryService)
        {
            this.todoCategoryService = todoCategoryService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<LabelServiceModel>> Get()
        {
            return await todoCategoryService.GetAllCategories();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public LabelServiceModel Get(Guid id)
        {
            var todoItem = todoCategoryService.GetById(id);
            return todoItem;
        }

        // POST api/values
        [HttpPost]
        public Guid Create([FromBody]LabelServiceModel value)
        {
            if (value == null)
                BadRequest();

            if (value != null)
            {
                todoCategoryService.Create(value);
                todoCategoryService.Save();
            }

            return value.Id;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Update(Guid id, [FromBody]LabelServiceModel value)
        {
            if (id != null || value != null)
            {
                var todoItem = todoCategoryService.GetById(id);

                if (todoItem != null)
                {
                    todoItem.IsActive = value.IsActive;
                    todoItem.Name = value.Name;

                    todoCategoryService.Update(todoItem);
                    todoCategoryService.Save();
                }
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var todoItem = todoCategoryService.GetById(id);

            if (todoItem != null)
            {
                todoCategoryService.Delete(id);
                todoCategoryService.Save();
            }
        }
    }
}

