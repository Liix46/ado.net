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
    class WorkersConfiguration : IEntityTypeConfiguration<Workers>
    {
        public void Configure(EntityTypeBuilder<Workers> builder)
        {
            _ = builder.HasData(
              new Workers[]
              {
                    new Workers { Id = 1, FirstName = "Alexander", LastName = "Fox", DateBirth = Convert.ToDateTime("22/10/1981") ,EmploymentDate = Convert.ToDateTime("04/08/2020")},
                    new Workers { Id = 2, FirstName = "John", LastName = "Bird", DateBirth = Convert.ToDateTime("05/02/1975") ,EmploymentDate = Convert.ToDateTime("09/08/2013"), DismissalDate = Convert.ToDateTime("20/06/2020")},
                    new Workers { Id = 3, FirstName = "Viktor", LastName = "Lion", DateBirth = Convert.ToDateTime("12/05/1992") ,EmploymentDate = Convert.ToDateTime("24/02/2018")},
                    new Workers { Id = 4, FirstName = "Elena", LastName = "Sunrise", DateBirth = Convert.ToDateTime("05/12/1990") ,EmploymentDate = Convert.ToDateTime("05/08/2016")},
                    new Workers { Id = 5, FirstName = "Ivan", LastName = "Pizza", DateBirth = Convert.ToDateTime("05/12/1987") ,EmploymentDate = Convert.ToDateTime("05/08/2004")},
                    new Workers { Id = 6, FirstName = "Katerine", LastName = "Snow", DateBirth = Convert.ToDateTime("05/12/1978") ,EmploymentDate = Convert.ToDateTime("24/05/2002")},
                    new Workers { Id = 7, FirstName = "Victory", LastName = "Light", DateBirth = Convert.ToDateTime("17/05/2000") ,EmploymentDate = Convert.ToDateTime("10/08/2021")},
                    new Workers { Id = 8, FirstName = "Vasya", LastName = "Petrov", DateBirth = Convert.ToDateTime("01/02/1985") ,EmploymentDate = Convert.ToDateTime("14/10/2007")},
              });
        }
    }
}

