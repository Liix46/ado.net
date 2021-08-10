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
    class ClientsConfiguration : IEntityTypeConfiguration<Clients>
    {
        public void Configure(EntityTypeBuilder<Clients> builder)
        {
            _ = builder.HasData(
              new Clients[]
              {
                    new Clients { Id = 1, FirstName = "Alex", LastName = "Boichev", Phone = "+3801235101"},
                    new Clients { Id = 2, FirstName = "Anastasia", LastName = "Boicheva", Phone = "+3804561202"},
                    new Clients { Id = 3, FirstName = "Lana", LastName = "Del Rey", Phone = "+3805554403"},
              });
        }
    }
}
