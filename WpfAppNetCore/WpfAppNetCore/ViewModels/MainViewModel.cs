using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;

using WpfAppNetCore.EventModel;
using WpfAppNetCore.DB;
using WpfAppNetCore.Views;

namespace WpfAppNetCore.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private readonly StepDataBase _database = new();
        public List<string> Tables { get; set; } = new();
        private string _selectedTable;
        private readonly MainWindow _mainWindow = (MainWindow)Application.Current.MainWindow;
        public MainViewModel()
        {
            Tables = _database.GetTables(Tables);
            _ = Tables.Remove("Specialists");
            _ = Tables.Remove("Groups");
            _ = Tables.Remove("ProgressStudies");
            _ = Tables.Remove("Positions");
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
        private RelayCommand _deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ??= new RelayCommand(obj =>
                    {
                        _ = _database.DeleteItem(SelectedTable, _mainWindow);
                    });
            }
        }

        private RelayCommand _editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return _editCommand =
                (_editCommand = new RelayCommand(obj =>
                {
                    AddItem("Edition", "Save");
                }));
            }
        }

        private void AddItem(string title = "Addition", string buttonName = "Add")
        {
            switch (SelectedTable)
            {
                case "Branches":
                    {
                        BranchWindow _window = new();
                        _window.Title = title;
                        _window.Btn_Ok.Content = buttonName;
                        _window.ShowDialog();
                    }
                    break;
                case "ContactsBranches":
                    {
                        ContactsBranchesWindow _window = new();
                        _window.Title = title;
                        _window.Btn_Ok.Content = buttonName;
                        _window.ShowDialog();
                    }
                    break;
                case "Position":
                    break;
                case "Workers":
                    break;
                case "Specialists":
                    break;
                case "Subjects":
                    break;
                case "NameCourses":
                    break;
                case "Courses":
                    {
                        CoursWindow _window = new();
                        _window.Title = title;
                        _window.Btn_Ok.Content = buttonName;
                        _window.ShowDialog();
                    }
                    break;
                case "Clients":
                    {
                        ClientWindow _window = new();
                        _window.Title = title;
                        _window.Btn_Ok.Content = buttonName;
                        _window.ShowDialog();
                    }
                    break;
                case "NameGroups":
                    break;
                case "Groups":
                    break;
                case "ProgressStudy":
                    break;
                default:
                    break;
            }
        }

        public string SelectedTable
        {
            get { return _selectedTable; }
            set
            {
                _selectedTable = value;
                _ = RefreshDataGrid(_selectedTable);
                _mainWindow.addButton.IsEnabled = true;
            }
        }



        private async Task RefreshDataGrid(string selectedTable)
        {
            await ShowObjectsAsync(selectedTable);
        }

        private async Task ShowObjectsAsync(string table)
        {
            switch (table)
            {
                case "Branches":
                    _mainWindow.mainDataGrid.ItemsSource = await StepDataBase.Context.Branches.ToListAsync();
                    break;
                case "ContactsBranches":
                    _mainWindow.mainDataGrid.ItemsSource = await StepDataBase.Context.ContactsBranches.ToListAsync();
                    break;
                case "Position":
                    _mainWindow.mainDataGrid.ItemsSource = await StepDataBase.Context.Positions.ToListAsync();
                    break;
                case "Workers":
                    _mainWindow.mainDataGrid.ItemsSource = await StepDataBase.Context.Workers.ToListAsync();
                    break;
                case "Specialists":
                    _mainWindow.mainDataGrid.ItemsSource = await StepDataBase.Context.Specialists.ToListAsync();
                    break;
                case "Subjects":
                    _mainWindow.mainDataGrid.ItemsSource = await StepDataBase.Context.Subjects.ToListAsync();
                    break;
                case "NameCourses":
                    _mainWindow.mainDataGrid.ItemsSource = await StepDataBase.Context.NameCourses.ToListAsync();
                    break;
                case "Courses":
                    _mainWindow.mainDataGrid.ItemsSource = await StepDataBase.Context.Courses.ToListAsync();
                    break;
                case "Clients":
                    _mainWindow.mainDataGrid.ItemsSource = await StepDataBase.Context.Clients.ToListAsync();
                    break;
                case "NameGroups":
                    _mainWindow.mainDataGrid.ItemsSource = await StepDataBase.Context.NameGroups.ToListAsync();
                    break;
                case "Groups":
                    _mainWindow.mainDataGrid.ItemsSource = await StepDataBase.Context.Groups.ToListAsync();
                    break;
                case "ProgressStudy":
                    _mainWindow.mainDataGrid.ItemsSource = await StepDataBase.Context.ProgressStudies.ToListAsync();
                    break;
            }
            _mainWindow.mainDataGrid.Items.Refresh();
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
