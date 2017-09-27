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
    public class TodoLabelService : ServiceBase, ITodoLabelService
    {
        private readonly ITodoLabelRepository todoCategoryRepository;
        public TodoLabelService(IUnitOfWork unitOfWork, ITodoLabelRepository todoCategoryRepository) : base(unitOfWork)
        {
            this.todoCategoryRepository = todoCategoryRepository;
        }

        public async Task<IEnumerable<LabelServiceModel>> GetAllCategories()
        {
            var allCategories = await todoCategoryRepository.GetAllAsync();
            IEnumerable<LabelServiceModel> returnCategories = Mapper.Map<IEnumerable<LabelServiceModel>>(allCategories);
            return returnCategories;
        }

        public void Create(LabelServiceModel entity)
        {
            var createObject = Mapper.Map<LearningCore.DataModels.TodoLabel>(entity);
            todoCategoryRepository.Add(createObject);
        }

        public void Delete(Guid id)
        {
            var delete = todoCategoryRepository.GetById(id);
            todoCategoryRepository.Delete(delete);
        }

        public LabelServiceModel GetById(Guid id)
        {
            var category = Mapper.Map<LabelServiceModel>(todoCategoryRepository.GetById(id));
            return category;
        }

        public LabelServiceModel GetByName(string name)
        {
            var category = Mapper.Map<LabelServiceModel>(todoCategoryRepository.GetCategoryByName(name));
            return category;
        }

        public void Update(LabelServiceModel entity)
        {
            var updateObject = Mapper.Map<LearningCore.DataModels.TodoLabel>(entity);
            todoCategoryRepository.Update(updateObject);
        }

        public void Save()
        {
            base.SaveContext();
        }
    }
}
