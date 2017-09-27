using System;
using System.Collections.Generic;

namespace LearningCore.Services.ServiceModels
{
    public class LabelServiceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TodoServiceModel> TodoServiceModels { get; set; }

        public LabelServiceModel()
        {

        }
    }
}
