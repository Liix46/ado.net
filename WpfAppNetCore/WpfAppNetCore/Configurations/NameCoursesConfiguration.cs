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
    class NameCoursesConfiguration : IEntityTypeConfiguration<NameCourses>
    {
        public void Configure(EntityTypeBuilder<NameCourses> builder)
        {
            builder.HasData(
              new NameCourses[]
              {
                    new NameCourses { Id = 1, Name= "Bakalavrat"},
                    new NameCourses { Id = 2, Name= "Magistracy"},
                    new NameCourses { Id = 3, Name= "Training University"},
              });
        }
    }
}
