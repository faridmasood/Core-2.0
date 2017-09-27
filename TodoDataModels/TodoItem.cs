using System;

namespace LearningCore.DataModels
{
    public class TodoItem 
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }

        public Guid LabelId { get; set; }
        public TodoLabel Label { get; set; }
    }
}
