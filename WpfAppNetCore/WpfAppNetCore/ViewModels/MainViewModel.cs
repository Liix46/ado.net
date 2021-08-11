using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfAppNetCore.Models;
using WpfAppNetCore.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WpfAppNetCore.DB;

namespace WpfAppNetCore.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private StepDataBase _database = new();

        public List<string> Tables { get; set; } = new List<string>();
        private string _selectedTable;

        public string SelectedTable
        {
            get => _selectedTable;
            set
            {
                _selectedTable = value;
                RefreshDataGrid(_selectedTable);
                _mainWindow.addButton.IsEnabled = true;
            }
        }
        private MainWindow _mainWindow = (MainWindow)Application.Current.MainWindow;

        public MainViewModel()
        {
            Tables = _database.GetTables(Tables);
            Tables.Remove("Grades");
        }

        private async Task RefreshDataGrid(string table)
        {
            await ShowObjectsAsync(table);
        }

        private async Task ShowObjectsAsync(string table)
        {
            _mainWindow.mainDataGrid.Items.Refresh();
        }

        private RelayCommand _addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand =
                (_addCommand = new RelayCommand(obj =>
                {
                    AddItem();
                }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
