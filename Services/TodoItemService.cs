using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LearningCore.Services.ServiceModels;
using LearningCore.DataStore.Infrastructure;
using LearningCore.DataStore.Repositories;
using AutoMapper;

namespace LearningCore.Services
{
    public class TodoItemService : ServiceBase, ITodoItemService
    {
        private readonly ITodoItemRepository todoItemRepository;
        public TodoItemService(IUnitOfWork unitOfWork, ITodoItemRepository todoItemRepository) : base(unitOfWork)
        {
            this.todoItemRepository = todoItemRepository;
        }

        public async Task<IEnumerable<TodoServiceModel>> GetAllTodo()
        {
            var todoItems = await todoItemRepository.GetAllAsync();
            var returnItems = Mapper.Map<IEnumerable<TodoServiceModel>>(todoItems);
            return returnItems;
        }

        public IEnumerable<TodoServiceModel> GetByCategory(Guid id)
        {
            var allItems = Mapper.Map<IEnumerable<TodoServiceModel>>(todoItemRepository.GetByCategory(id));
            return allItems;
        }

        public void Create(TodoServiceModel entity)
        {
            var creatObject = Mapper.Map<LearningCore.DataModels.TodoItem>(entity);
            todoItemRepository.Add(creatObject);
        }

        public void Delete(Guid id)
        {
            var delete = todoItemRepository.GetById(id);
            todoItemRepository.Delete(delete);
        }

        public TodoServiceModel GetById(Guid id)
        {
            var item = Mapper.Map<TodoServiceModel>(todoItemRepository.GetById(id));
            return item;
        }

        public void Update(TodoServiceModel entity)
        {
            var updateObject = Mapper.Map<LearningCore.DataModels.TodoItem>(entity);
            todoItemRepository.Update(updateObject);
        }

        public void Save()
        {
            base.SaveContext();
        }
    }
}
