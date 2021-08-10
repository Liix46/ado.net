using Microsoft.EntityFrameworkCore;
using System;
using WpfAppNetCore.Models;

namespace WpfAppNetCore.Configurations
{
    class ContactsBranchesConfiguration : IEntityTypeConfiguration<ContactsBranches>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ContactsBranches> builder)
        {
            _ = builder.HasData(
             new ContactsBranches[]
             {
                    new ContactsBranches { BranchesId = 1, WebSite = "Step.org/Odessa", Phone = "+380964030500"},
                    new ContactsBranches { BranchesId = 2, WebSite = "Step.org/Kiev", Phone = "+380964030501"},
                    new ContactsBranches { BranchesId = 3, WebSite = "Step.org/Lviv", Phone = "+380964030502"},
                    new ContactsBranches { BranchesId = 4, WebSite = "Step.org/Nikolaev", Phone = "+380964030503"},
                    new ContactsBranches { BranchesId = 5, WebSite = "Step.org/Zhytomyr", Phone = "+380964030504"}
             });

            _ = builder
           .HasOne(p => p.Branches)
           .WithMany(t => t.ContactsBranches)
           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
