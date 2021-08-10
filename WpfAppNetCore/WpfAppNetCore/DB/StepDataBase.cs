using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WpfAppNetCore.ViewModels;

namespace WpfAppNetCore.DB
{
    public enum Chose
    {
        YES = 0,
        NO
    }
    internal class StepDataBase
    {
        static private StepContext context;
        static public StepContext Context
        {
            get => context;
            set => context = value;
        }
        public string ConnectionString { get; set; }

        public DbContextOptions<StepContext> Options { get; set; }

        public StepDataBase()
        {
            IConfigurationRoot configuration =
                new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            ConnectionString = configuration.GetConnectionString("DefaultConnection");

            DbContextOptions<StepContext> options =
                new DbContextOptionsBuilder<StepContext>()
                    .UseSqlServer(ConnectionString)
                    .Options;
            Options = options;

            context = new StepContext(options);

            context.Branches.Load();
            context.Clients.Load();
            context.ContactsBranches.Load();
            context.Courses.Load();
            context.Groups.Load();
            context.NameCourses.Load();
            context.NameGroups.Load();
            context.Positions.Load();
            context.ProgressStudies.Load();
            context.Specialists.Load();
            context.Subjects.Load();
            context.Workers.Load();
        }

        public List<string> GetTables(List<string> Tables)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                // Открываем соединение
                connection.Open();

                DataTable schema = connection.GetSchema("Tables");

                foreach (DataRow row in schema.Rows)
                {
                    //почему row[2] что находиться в 2-ом элементе row?
                    Tables.Add(row[2].ToString());
                }
            } // закрываем соединение

            return Tables;
        }
    }

}
