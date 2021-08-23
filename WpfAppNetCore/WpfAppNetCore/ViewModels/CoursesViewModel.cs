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
    internal class CoursesViewModel : INotifyPropertyChanged
    {
        private MainWindow _mainWindow = (MainWindow)Application.Current.MainWindow;
        private CoursWindow _window;
        private RelayCommand _saveCommand;

        public CoursesViewModel(CoursWindow window)
        {
            _window = window;
            if (_mainWindow.mainDataGrid.SelectedItem != null)
            {
                string fullString = _mainWindow.mainDataGrid.SelectedItem.ToString();

                //_window.TBox_CountHours.Text = fullString.Substring(fullString.IndexOf("TBox_CountHours = ") + 12, fullString.Substring(fullString.IndexOf("TBox_CountHours = ") + 12).IndexOf(","));
                //_window.TBox_Describe.Text = fullString.Substring(fullString.IndexOf("LastName = ") + 11, fullString.Substring(fullString.IndexOf("LastName = ") + 11).IndexOf(","));
                //_window.TBox_NameCoursesId.Text = fullString.Substring(fullString.IndexOf("BirthDate = ") + 12, fullString.Substring(fullString.IndexOf("BirthDate = ") + 12).IndexOf(","));
                //_window.TBox_SubjectsId.Text = fullString.Substring(fullString.IndexOf("Class = ") + 8, (fullString.Substring(fullString.LastIndexOf("= ")).IndexOf("}") - 3));
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
                            _ = AddCours(_window.TBox_CountHours.Text, _window.TBox_Describe.Text, _window.TBox_NameCoursesId.Text, _window.TBox_SubjectsId.Text);
                        else
                            _ = EditCours();
                    }));
            }
        }

        public async Task EditCours()
        {
            int i = _mainWindow.mainDataGrid.SelectedIndex;
            string stringItem = _mainWindow.mainDataGrid.Items[i].ToString();
            string stringId = stringItem.Substring(0, stringItem.IndexOf(";"));

            int id = int.Parse(stringId);

            Courses editCours = await StepDataBase.Context.Courses.FirstOrDefaultAsync(a => a.Id == id);

            if (editCours != null)
            {

                editCours.CountHours = int.Parse(_window.TBox_CountHours.Text);
                editCours.Describe = _window.TBox_Describe.Text;
                editCours.NameCoursesId = int.Parse(_window.TBox_NameCoursesId.Text);
                editCours.SubjectsId = int.Parse(_window.TBox_SubjectsId.Text);

                _ = StepDataBase.Context.Update(editCours);
            }
            _ = await StepDataBase.Context.SaveChangesAsync();
            _ = MessageBox.Show("Cours has been successfully edited!");
        }

        private async Task AddCours(string countHours, string describe, string nameCourseId, string subjectId)
        {
            Courses newCours = new()
            {
                CountHours = int.Parse(countHours),
                Describe = describe,
                NameCoursesId = int.Parse(nameCourseId),
                SubjectsId = int.Parse(subjectId),
                NameCourses = null,
                Subjects = null
            };

            _ = await StepDataBase.Context.Courses.AddAsync(newCours);
            _ = await StepDataBase.Context.SaveChangesAsync();

            _ = MessageBox.Show("A new cours has been successfully added!");

            ClearTextBoxes();

            void ClearTextBoxes()
            {
                _window.TBox_CountHours.Text = "";
                _window.TBox_Describe.Text = "";
                _window.TBox_NameCoursesId.Text = "";
                _window.TBox_SubjectsId.Text = "";
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
