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
    class SpecialistsConfiguration : IEntityTypeConfiguration<Specialists>
    {
        public void Configure(EntityTypeBuilder<Specialists> builder)
        {
            _ = builder.HasData(
              new Specialists[]
              {
                    new Specialists { Id = 1, BranchesId = 1, WorkersId = 1, PositionId = 1},
                    new Specialists { Id = 2, BranchesId = 2, WorkersId = 2, PositionId = 1},
                    new Specialists { Id = 3, BranchesId = 3, WorkersId = 3, PositionId = 1},

                    new Specialists { Id = 4, BranchesId = 4, WorkersId = 4, PositionId = 1},
                    new Specialists { Id = 5, BranchesId = 5, WorkersId = 5, PositionId = 1},
                    new Specialists { Id = 6, BranchesId = 1, WorkersId = 6, PositionId = 2},
                    new Specialists { Id = 7, BranchesId = 2, WorkersId = 7, PositionId = 2},
                    new Specialists { Id = 8, BranchesId = 3, WorkersId = 8, PositionId = 2},

                    new Specialists { Id = 9, BranchesId = 4, WorkersId = 4, PositionId = 2},
                    new Specialists { Id = 10, BranchesId = 5, WorkersId = 5, PositionId = 2},
                    new Specialists { Id = 11, BranchesId = 1, WorkersId = 7, PositionId = 3},

                    new Specialists { Id = 12, BranchesId = 2, WorkersId = 2, PositionId = 3},
                    new Specialists { Id = 13, BranchesId = 3, WorkersId = 3, PositionId = 3},
                    new Specialists { Id = 14, BranchesId = 4, WorkersId = 4, PositionId = 3}
              });

            _ = builder
           .HasOne(p => p.Branches)
           .WithMany(t => t.Specialists)
           .OnDelete(DeleteBehavior.Restrict);

            _ = builder
           .HasOne(p => p.Workers)
           .WithMany(t => t.Specialists)
           .OnDelete(DeleteBehavior.Restrict);

            _ = builder
           .HasOne(p => p.Position)
           .WithMany(t => t.Specialists)
           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

