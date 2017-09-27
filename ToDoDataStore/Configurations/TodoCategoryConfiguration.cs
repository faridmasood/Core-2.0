using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;
using LearningCore.DataModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningCore.DataStore.DataStoreConfigurations
{
    class TodoCategoryConfiguration : IEntityTypeConfiguration<TodoLabel>
    {
        public void Configure(EntityTypeBuilder<TodoLabel> builder)
        {
            builder.ToTable("TodoCategory");
            builder.Property(t=>t.Name).IsRequired();
        }
    }
}
