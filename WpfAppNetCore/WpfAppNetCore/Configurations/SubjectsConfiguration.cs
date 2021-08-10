using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppNetCore.Models;

namespace WpfAppNetCore.Configurations
{
    class SubjectsConfiguration : IEntityTypeConfiguration<Subjects>
    {
        public void Configure(EntityTypeBuilder<Subjects> builder)
        {
            _ = builder.HasData(
               new Subjects[]
               {
                    new Subjects { Id = 1, Name = "C++"},
                    new Subjects { Id = 2, Name = "C#"},
                    new Subjects { Id = 3, Name = "JavaScript"}
               });
        }
    }
}

