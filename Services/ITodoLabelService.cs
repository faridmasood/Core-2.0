using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LearningCore.Services.ServiceModels;

namespace LearningCore.Services
{
    public interface ITodoLabelService : IService<LabelServiceModel>
    {
        Task<IEnumerable<LabelServiceModel>> GetAllCategories();
        LabelServiceModel GetByName(string name);
    }
}
