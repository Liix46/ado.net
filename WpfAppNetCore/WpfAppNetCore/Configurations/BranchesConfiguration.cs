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
    class BranchesConfiguration : IEntityTypeConfiguration<Branches>
    {
        public void Configure(EntityTypeBuilder<Branches> builder)
        {
            _ = builder.HasData(
                new Branches[]
                {
                    new Branches { Id = 1, Country = "Ukraine", City = "Odessa", Street = "Sadovaya 24"},
                    new Branches { Id = 2, Country = "Ukraine", City = "Kiev", Street = "Sadovaya 12'"},
                    new Branches { Id = 3, Country = "Ukraine", City = "Lviv", Street = "Sadovaya 10"},
                    new Branches { Id = 4, Country = "Ukraine", City = "Nikolaev", Street = "Sadovaya 8"},
                    new Branches { Id = 5, Country = "Ukraine", City = "Zhytomyr", Street = "Sadovaya 5"},
                });
        }
    }
}
