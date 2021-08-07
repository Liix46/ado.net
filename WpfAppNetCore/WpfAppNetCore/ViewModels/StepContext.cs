using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppNetCore.Models;

namespace WpfAppNetCore.ViewModels
{
    class StepContext :DbContext, INotifyPropertyChanged
    {
        public StepContext(DbContextOptions<StepContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public virtual DbSet<Branches> Branches { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<ContactsBranches> ContactsBranches { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<NameCourses> NameCourses { get; set; }
        public virtual DbSet<NameGroups> NameGroups { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<ProgressStudy> ProgressStudies { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StepDatabase;Trusted_Connection=True;");
            }
        }
    }
}
