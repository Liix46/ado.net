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
    class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            _ = builder.HasData(
              new Position[]
              {
                    new Position { Id = 1, Name = "C++ teacher", RateHour = 1},
                    new Position { Id = 2, Name = "C# teacher", RateHour = 2},
                    new Position { Id = 3, Name = "JavaScript teacher", RateHour = 3}
              });
        }
    }
}
