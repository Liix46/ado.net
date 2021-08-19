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
    class ClientsViewModel : INotifyPropertyChanged
    {
        private MainWindow _mainWindow = (MainWindow)Application.Current.MainWindow;
        private ClientWindow _window;

        private RelayCommand _saveCommand;

        public ClientsViewModel(ClientWindow window)
        {
            _window = window;

            if (_mainWindow.mainDataGrid.SelectedItem != null)
            {
                string fullString = _mainWindow.mainDataGrid.SelectedItem.ToString();

                _window.TBox_FirstName.Text = fullString.Substring(fullString.IndexOf(";") + 1, fullString.Substring(fullString.IndexOf(";") + 1).IndexOf(";"));
                _window.TBox_LastName.Text = fullString.Substring(fullString.Substring(fullString.IndexOf(";") + 1).IndexOf(";") + 3, fullString.Substring(fullString.Substring(fullString.IndexOf(";") + 1).IndexOf(";") + 3).IndexOf(";"));
                _window.TBox_Phone.Text = fullString.Substring(fullString.LastIndexOf(";") + 1);
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
                            _ = AddClient(_window.TBox_FirstName.Text, _window.TBox_LastName.Text, _window.TBox_Phone.Text);
                        else
                            _ = EditClient();
                    }));
            }
        }

        public async Task EditClient()
        {
            int i = _mainWindow.mainDataGrid.SelectedIndex;
            string stringItem = _mainWindow.mainDataGrid.Items[i].ToString();
            string stringId = stringItem.Substring(0, stringItem.IndexOf(";"));

            int id = int.Parse(stringId);

            Clients editClient = await StepDataBase.Context.Clients.FirstOrDefaultAsync(a => a.Id == id);

            if (editClient != null)
            {

                editClient.FirstName = _window.TBox_FirstName.Text;
                editClient.LastName = _window.TBox_LastName.Text;
                editClient.Phone = _window.TBox_Phone.Text;

                _ = StepDataBase.Context.Update(editClient);
            }
            _ = await StepDataBase.Context.SaveChangesAsync();
            _ = MessageBox.Show("Academy has been successfully edited!");
        }

        private async Task AddClient(string firstname, string lastname, string phone)
        {
            Clients newCLient = new()
            {
                FirstName = firstname,
                LastName = lastname,
                Phone = phone,
                Groups = null
            };

            _ = await StepDataBase.Context.Clients.AddAsync(newCLient);
            _ = await StepDataBase.Context.SaveChangesAsync();

            _ = MessageBox.Show("A new academy has been successfully added!");

            ClearTextBoxes();

            void ClearTextBoxes()
            {
                _window.TBox_FirstName.Text = "";
                _window.TBox_LastName.Text = "";
                _window.TBox_Phone.Text = "";
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
