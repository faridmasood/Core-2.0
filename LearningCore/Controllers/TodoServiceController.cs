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
    public class TodoServiceController : BaseController
    {
        private readonly ITodoItemService todoItemService;

        public TodoServiceController(ITodoItemService todoItemService)
        {
            this.todoItemService = todoItemService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<TodoServiceModel>> Get()
        {
            return await todoItemService.GetAllTodo();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TodoServiceModel Get(Guid id)
        {
            var todoItem = todoItemService.GetById(id);
            return todoItem;
        }

        // POST api/values
        [HttpPost]
        public Guid Create([FromBody]TodoServiceModel value)
        {
            if (value == null)
                BadRequest();

            if (value != null)
            {
                todoItemService.Create(value);
                todoItemService.Save();
            }

            return value.Id;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Update(Guid id, [FromBody]TodoServiceModel value)
        {
            if (id != null || value != null)
            {
                var todoItem = todoItemService.GetById(id);

                if (todoItem != null)
                {
                    todoItem.DueDate = value.DueDate;
                    todoItem.IsComplete = value.IsComplete;
                    todoItem.StartDate = value.StartDate;
                    todoItem.Text = value.Text;
                    todoItem.LabelServiceModelId = value.LabelServiceModelId;

                    todoItemService.Update(todoItem);
                    todoItemService.Save();
                }
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var todoItem = todoItemService.GetById(id);

            if (todoItem != null)
            {
                todoItemService.Delete(id);
                todoItemService.Save();
            }
        }
    }
}
