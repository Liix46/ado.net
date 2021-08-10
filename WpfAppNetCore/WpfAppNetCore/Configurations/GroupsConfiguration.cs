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
    class GroupsConfiguration : IEntityTypeConfiguration<Groups>
    {
        public void Configure(EntityTypeBuilder<Groups> builder)
        {
            _ = builder.HasData(
               new Groups[]
               {
                    new Groups { Id = 1, ClientsId = 1, NameCoursesId = 1, NameGroupsId = 1},
                    new Groups { Id = 2, ClientsId = 2, NameCoursesId = 2, NameGroupsId = 2},
                    new Groups { Id = 3, ClientsId = 3, NameCoursesId = 3, NameGroupsId = 3},
               });

            _ = builder
           .HasOne(p => p.Clients)
           .WithMany(t => t.Groups)
           .OnDelete(DeleteBehavior.Restrict);
            _ = builder
           .HasOne(p => p.NameCourses)
           .WithMany(t => t.Groups)
           .OnDelete(DeleteBehavior.Restrict);
            _ = builder
           .HasOne(p => p.NameGroups)
           .WithMany(t => t.Groups)
           .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
