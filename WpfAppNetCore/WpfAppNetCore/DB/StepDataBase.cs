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
using WpfAppNetCore.Models;
using WpfAppNetCore.ViewModels;

namespace WpfAppNetCore.DB
{

    public enum Choses
    {
        YES,
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
        public Choses IsConfirmed()
        {
            var result = MessageBox.Show("Are you sure to delete this item?", "Deleting item", MessageBoxButton.YesNo);

            return (Choses)result;
        }

        internal async Task DeleteItem(string selectedTable, MainWindow window)
        {
            if (IsConfirmed() == Choses.NO)
                return;

            int i = window.mainDataGrid.SelectedIndex;
            string stringItem = window.mainDataGrid.Items[i].ToString();  // this give you access to the row
            string stringId = null;

            stringId = stringItem.Substring(0, stringItem.IndexOf(";"));

            int id = int.Parse(stringId);

            switch (selectedTable)
            {
                case "Branches":
                    Branches deleteBranch = await Context.Branches.FirstOrDefaultAsync(a => a.Id == id);
                    if (deleteBranch != null)
                    {
                        _ = Context.Branches.Remove(deleteBranch);
                        _ = await context.SaveChangesAsync();

                        /// refresh datagrid rows
                        window.mainDataGrid.ItemsSource = await Context.Branches.ToListAsync();
                    }
                    break;
                case "Clients":
                    Clients deleteClient = await Context.Clients.FirstOrDefaultAsync(a => a.Id == id);
                    if (deleteClient != null)
                    {
                        _ = Context.Clients.Remove(deleteClient);
                        _ = await context.SaveChangesAsync();

                        window.mainDataGrid.ItemsSource = await Context.Clients.ToListAsync();
                    }
                    break;
                case "ContactsBranches":
                    ContactsBranches deleteContactBranch = await Context.ContactsBranches.FirstOrDefaultAsync(a => a.Id == id);
                    if (deleteContactBranch != null)
                    {
                        _ = Context.ContactsBranches.Remove(deleteContactBranch);
                        _ = await context.SaveChangesAsync();

                        window.mainDataGrid.ItemsSource = await Context.ContactsBranches.ToListAsync();
                    }
                    break;
                default:
                    break;
            }

        }


        public List<string> GetTables(List<string> Tables)
        {
            using (SqlConnection connection = new(ConnectionString))
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
