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
    internal class NameCoursesViewModel : INotifyPropertyChanged
    {
        private MainWindow _mainWindow = (MainWindow)Application.Current.MainWindow;
        private NameCoursWindow _window;

        private RelayCommand _saveCommand;

        public NameCoursesViewModel(NameCoursWindow window)
        {
            _window = window;

            if (_mainWindow.mainDataGrid.SelectedItem != null)
            {
                string fullString = _mainWindow.mainDataGrid.SelectedItem.ToString();
                _window.TBox_NameCourse.Text = fullString.Substring(fullString.LastIndexOf(";") + 1);

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
                            _ = AddNameCourse(_window.TBox_NameCourse.Text);
                        else
                            _ = EditNameCourse();
                    }));
            }
        }

        public async Task EditNameCourse()
        {
            int i = _mainWindow.mainDataGrid.SelectedIndex;
            string stringItem = _mainWindow.mainDataGrid.Items[i].ToString();
            string stringId = stringItem.Substring(0, stringItem.IndexOf(";"));

            int id = int.Parse(stringId);

            NameCourses editNameCourse = await StepDataBase.Context.NameCourses.FirstOrDefaultAsync(a => a.Id == id);

            if (editNameCourse != null)
            {

                editNameCourse.Name = _window.TBox_NameCourse.Text;

                _ = StepDataBase.Context.Update(editNameCourse);
            }
            _ = await StepDataBase.Context.SaveChangesAsync();
            _ = MessageBox.Show("Name course has been successfully edited!");
        }

        private async Task AddNameCourse(string name)
        {
            NameCourses newNameCourse = new()
            {
                Name = name,
                Courses = null,
                Groups = null
            };

            _ = await StepDataBase.Context.NameCourses.AddAsync(newNameCourse);
            _ = await StepDataBase.Context.SaveChangesAsync();

            _ = MessageBox.Show("A name course has been successfully added!");

            ClearTextBoxes();

            void ClearTextBoxes()
            {
                _window.TBox_NameCourse.Text = "";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
