using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppNetCore.ViewModels;

namespace WpfAppNetCore
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
    
        }

        private void mainDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string headername = e.Column.Header.ToString();

            //Cancel the column you don't want to generate 
            if (headername == "Id" || headername == "ContactsBranches" || headername == "Specialists" ||
                headername == "Courses" || headername == "NameCoursesId" || headername == "NameGroupsId" ||
                headername == "ProgressStudy" || headername == "PositionId" || headername == "Groups"
                || headername == "SubjectsId" || headername == "BranchesId" || headername == "WorkersId")
            {
                e.Cancel = true;
            }
                        
        }


        private void mainDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (mainDataGrid.SelectedItem != null)
            {
                deleteButton.IsEnabled = true;
                editButton.IsEnabled = true;
            }
            else
            {
                deleteButton.IsEnabled = false;
                editButton.IsEnabled = false;
            }
        }
    }
}
