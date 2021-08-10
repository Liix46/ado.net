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
    class CoursesConfiguration : IEntityTypeConfiguration<Courses>
    {
        public void Configure(EntityTypeBuilder<Courses> builder)
        {
            _ = builder.HasData(
             new Courses[]
             {
                    new Courses { Id = 1,  NameCoursesId = 1, SubjectsId = 1,CountHours = 30, Describe = "Programming course about C++"},
                    new Courses { Id = 2,  NameCoursesId = 1, SubjectsId = 2,CountHours = 30, Describe = "Programming course about C#"},
                    new Courses { Id = 3,  NameCoursesId = 1, SubjectsId = 3,CountHours = 30, Describe = "Programming course about JS"},

                    new Courses { Id = 4,  NameCoursesId = 2, SubjectsId = 1,CountHours = 20, Describe = "Pro-course on programming about C++"},
                    new Courses { Id = 5,  NameCoursesId = 2, SubjectsId = 2,CountHours = 20, Describe = "Pro-course on programming about C#"},
                    new Courses { Id = 6,  NameCoursesId = 2, SubjectsId = 3,CountHours = 20, Describe = "Pro-course on programming about JS"},

                    new Courses { Id = 7,  NameCoursesId = 3, SubjectsId = 1,CountHours = 15, Describe = "Lite-course on programming about C++"},
                    new Courses { Id = 8,  NameCoursesId = 3, SubjectsId = 2,CountHours = 15, Describe = "Lite-course on programming about C#"},
                    new Courses { Id = 9,  NameCoursesId = 3, SubjectsId = 3,CountHours = 15, Describe = "Lite-course on programming about JS"},
             });

            _ = builder
            .HasOne(p => p.NameCourses)
            .WithMany(t => t.Courses)
            .OnDelete(DeleteBehavior.Restrict);

            _ = builder
            .HasOne(p => p.Subjects)
            .WithMany(t => t.Courses)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

