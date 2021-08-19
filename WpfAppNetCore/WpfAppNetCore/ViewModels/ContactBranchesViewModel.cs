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
    internal class ContactBranchesViewModel : INotifyPropertyChanged
    {
        private MainWindow _mainWindow = (MainWindow)Application.Current.MainWindow;
        private ContactsBranchesWindow _window;

        private RelayCommand _saveCommand;

        public ContactBranchesViewModel(ContactsBranchesWindow window)
        {
            _window = window;

            if (_mainWindow.mainDataGrid.SelectedItem != null)
            {
                string fullString = _mainWindow.mainDataGrid.SelectedItem.ToString();

                _window.TBox_WebSite.Text = fullString.Substring(fullString.IndexOf(";") + 1, fullString.Substring(fullString.IndexOf(";") + 1).IndexOf(";"));
                _window.TBox_Phone.Text = fullString.Substring(fullString.Substring(fullString.IndexOf(";") + 1).IndexOf(";") + 3, fullString.Substring(fullString.Substring(fullString.IndexOf(";") + 1).IndexOf(";") + 3).IndexOf(";"));
                _window.TBox_BranchId.Text = fullString.Substring(fullString.LastIndexOf(";") + 1);
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
                            _ = AddContactBranch(_window.TBox_WebSite.Text, _window.TBox_Phone.Text, _window.TBox_BranchId.Text);
                        else
                            _ = EditContactBranch();
                    }));
            }
        }

        public async Task EditContactBranch()
        {
            int i = _mainWindow.mainDataGrid.SelectedIndex;
            string stringItem = _mainWindow.mainDataGrid.Items[i].ToString();
            string stringId = stringItem.Substring(0, stringItem.IndexOf(";"));

            int id = int.Parse(stringId);

            ContactsBranches editContactBranch = await StepDataBase.Context.ContactsBranches.FirstOrDefaultAsync(a => a.Id == id);

            if (editContactBranch != null)
            {

                editContactBranch.WebSite = _window.TBox_WebSite.Text;
                editContactBranch.Phone = _window.TBox_Phone.Text;
                editContactBranch.BranchesId = int.Parse(_window.TBox_BranchId.Text);

                _ = StepDataBase.Context.Update(editContactBranch);
            }
            _ = await StepDataBase.Context.SaveChangesAsync();
            _ = MessageBox.Show("Academy has been successfully edited!");
        }

        private async Task AddContactBranch(string website, string phone, string branchId)
        {
            ContactsBranches newContactBranch = new()
            {
                WebSite = website,
                Phone = phone,
                BranchesId = int.Parse(branchId),
                Branches = null,
            };

            _ = await StepDataBase.Context.ContactsBranches.AddAsync(newContactBranch);
            _ = await StepDataBase.Context.SaveChangesAsync();

            _ = MessageBox.Show("A new academy has been successfully added!");

            ClearTextBoxes();

            void ClearTextBoxes()
            {
                _window.TBox_WebSite.Text = "";
                _window.TBox_Phone.Text = "";
                _window.TBox_BranchId.Text = "";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
