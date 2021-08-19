using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppNetCore.DB;
using WpfAppNetCore.EventModel;
using WpfAppNetCore.Models;
using WpfAppNetCore.Views;

namespace WpfAppNetCore.ViewModels
{
    internal class BranchesViewModel : INotifyPropertyChanged
    {
        private MainWindow _mainWindow = (MainWindow)Application.Current.MainWindow;
        private BranchWindow _window;

        private RelayCommand _saveCommand;

        public BranchesViewModel(BranchWindow window)
        {
            _window = window;

            if (_mainWindow.mainDataGrid.SelectedItem != null)
            {
                string fullString = _mainWindow.mainDataGrid.SelectedItem.ToString();

                _window.TBox_Country.Text = fullString.Substring(fullString.IndexOf(";") + 1, fullString.Substring(fullString.IndexOf(";") + 1).IndexOf(";"));
                _window.TBox_City.Text = fullString.Substring(fullString.Substring(fullString.IndexOf(";") + 1).IndexOf(";") + 3, fullString.Substring(fullString.Substring(fullString.IndexOf(";") + 1).IndexOf(";") + 3).IndexOf(";"));
                _window.TBox_Street.Text = fullString.Substring(fullString.LastIndexOf(";") + 1);
            }
        }
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand =
                    (_saveCommand = new RelayCommand(obj =>
                    {
                       if (_window.Title == "Addition")
                           _ = AddBranch(_window.TBox_Country.Text, _window.TBox_City.Text, _window.TBox_Street.Text);
                       else
                            _ = EditBranch();
                    }));
            }
        }

        public async Task EditBranch()
        {
            int i = _mainWindow.mainDataGrid.SelectedIndex;
            string stringItem = _mainWindow.mainDataGrid.Items[i].ToString();
            string stringId = stringItem.Substring(0, stringItem.IndexOf(";"));

            int id = int.Parse(stringId);

            Branches editBranch = await StepDataBase.Context.Branches.FirstOrDefaultAsync(a => a.Id == id);

            if (editBranch != null)
            {

                editBranch.Country = _window.TBox_Country.Text;
                editBranch.City = _window.TBox_City.Text;
                editBranch.Street = _window.TBox_Street.Text;

                _ = StepDataBase.Context.Update(editBranch);
            }
            _ = await StepDataBase.Context.SaveChangesAsync();
            _ = MessageBox.Show("Academy has been successfully edited!");
        }

        private async Task AddBranch(string country, string city, string street)
        {
            Branches newBranch = new()
            {
                Country = country,
                City = city,
                Street = street,
                ContactsBranches = null,
                Specialists = null
            };

            _ = await StepDataBase.Context.Branches.AddAsync(newBranch);
            _ = await StepDataBase.Context.SaveChangesAsync();

            _ = MessageBox.Show("A new academy has been successfully added!");

            ClearTextBoxes();

            void ClearTextBoxes()
            {
                _window.TBox_Country.Text = "";
                _window.TBox_City.Text = "";
                _window.TBox_Street.Text = "";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
