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
    class NameGroupsViewModel : INotifyPropertyChanged
    {
        private MainWindow _mainWindow = (MainWindow)Application.Current.MainWindow;
        private NameGroupWindow _window;
        private RelayCommand _saveCommand;

        public NameGroupsViewModel(NameGroupWindow window)
        {
            _window = window;
            if (_mainWindow.mainDataGrid.SelectedItem != null)
            {
                string fullString = _mainWindow.mainDataGrid.SelectedItem.ToString();
                _window.TBox_NameGroup.Text = fullString.Substring(fullString.LastIndexOf(";") + 1);

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
                            _ = AddNameGroup(_window.TBox_NameGroup.Text);
                        else
                            _ = EditNameGroup();
                    }));
            }
        }

        public async Task EditNameGroup()
        {
            int i = _mainWindow.mainDataGrid.SelectedIndex;
            string stringItem = _mainWindow.mainDataGrid.Items[i].ToString();
            string stringId = stringItem.Substring(0, stringItem.IndexOf(";"));

            int id = int.Parse(stringId);

            NameGroups editNameGroup = await StepDataBase.Context.NameGroups.FirstOrDefaultAsync(a => a.Id == id);

            if (editNameGroup != null)
            {

                editNameGroup.Name = _window.TBox_NameGroup.Text;

                _ = StepDataBase.Context.Update(editNameGroup);
            }
            _ = await StepDataBase.Context.SaveChangesAsync();
            _ = MessageBox.Show("Name group has been successfully edited!");
        }

        private async Task AddNameGroup(string name)
        {
            NameGroups newNameGroup = new()
            {
                Name = name,
                Groups = null
            };

            _ = await StepDataBase.Context.NameGroups.AddAsync(newNameGroup);
            _ = await StepDataBase.Context.SaveChangesAsync();

            _ = MessageBox.Show("A name group has been successfully added!");

            ClearTextBoxes();

            void ClearTextBoxes()
            {
                _window.TBox_NameGroup.Text = "";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
