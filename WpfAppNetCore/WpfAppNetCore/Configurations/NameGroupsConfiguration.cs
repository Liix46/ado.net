using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WpfAppNetCore.Models;

namespace WpfAppNetCore.Configurations
{
    class NameGroupsConfiguration : IEntityTypeConfiguration<NameGroups>
    {
        public void Configure(EntityTypeBuilder<NameGroups> builder)
        {
            _ = builder.HasData(
             new NameGroups[]
             {
                    new NameGroups { Id = 1, Name = "KN-181-U"},
                    new NameGroups { Id = 1, Name = "KN-191-U"},
                    new NameGroups { Id = 1, Name = "KN-201-U"},
             });
        }
    }
}