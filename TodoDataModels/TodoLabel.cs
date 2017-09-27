using System;
using System.Collections.Generic;

namespace LearningCore.DataModels
{
    public class TodoLabel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}
