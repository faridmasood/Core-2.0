using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;
using LearningCore.DataModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningCore.DataStore.DataStoreConfigurations
{
    class TodoItemConfiguration: IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.ToTable("TodoItem");
            builder.Property(t=>t.Text).IsRequired();
        }
    }
}
