using System;

namespace LearningCore.Services.ServiceModels
{
    public class TodoServiceModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }

        public Guid LabelServiceModelId { get; set; }
        public LabelServiceModel LabelServiceModel { get; set; }
    }
}
