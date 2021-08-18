using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppNetCore.Configurations;
using WpfAppNetCore.Models;

namespace WpfAppNetCore.ViewModels
{
    class StepContext :DbContext
    {
        public virtual DbSet<Branches> Branches { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<ContactsBranches> ContactsBranches { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<NameCourses> NameCourses { get; set; }
        public virtual DbSet<NameGroups> NameGroups { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<ProgressStudy> ProgressStudies { get; set; }
        public virtual DbSet<Specialists> Specialists { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }


        public StepContext(DbContextOptions<StepContext> options) : base(options)
        {
            ConnectToDatabase();
        }
        private void ConnectToDatabase()
        {
            if (Database.CanConnect())
            {
                Database.EnsureDeleted();
            }
            //Database.EnsureDeleted();
            // Создаем БД
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Выводим в режиме отладки запросы, отправляемые EF, в окно Output (меню Visual Studio: View -> Output).
            // Метод DbContextOptionsBuilder.LogTo был добавлен только начиная с EF Core 5.0.
            optionsBuilder.LogTo(s => System.Diagnostics.Debug.WriteLine(s));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BranchesConfiguration());
            modelBuilder.ApplyConfiguration(new ClientsConfiguration());
            modelBuilder.ApplyConfiguration(new ContactsBranchesConfiguration());
            modelBuilder.ApplyConfiguration(new CoursesConfiguration());
            modelBuilder.ApplyConfiguration(new GroupsConfiguration());
            modelBuilder.ApplyConfiguration(new NameCoursesConfiguration());
            modelBuilder.ApplyConfiguration(new NameGroupsConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new ProgressStudyConfiguration());
            modelBuilder.ApplyConfiguration(new SpecialistsConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectsConfiguration());
            modelBuilder.ApplyConfiguration(new WorkersConfiguration());
        }
    }
}
