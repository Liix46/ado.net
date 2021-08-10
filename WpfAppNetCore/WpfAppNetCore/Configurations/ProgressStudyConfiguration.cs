using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WpfAppNetCore.Models;

namespace WpfAppNetCore.Configurations
{
    class ProgressStudyConfiguration : IEntityTypeConfiguration<ProgressStudy>
    {
        public void Configure(EntityTypeBuilder<ProgressStudy> builder)
        {
            _ = builder.HasData(
               new ProgressStudy[]
               {
                    new ProgressStudy { Id = 1, Subject = "C++", CountHours = 5, SpecialistsId = 1,GroupsId = 1 },
                    new ProgressStudy { Id = 2, Subject = "C#", CountHours = 15, SpecialistsId = 6,GroupsId = 2 },
                    new ProgressStudy { Id = 3, Subject = "JavaScript", CountHours = 10, SpecialistsId = 12,GroupsId = 3 },
               });
        }
    }
}
