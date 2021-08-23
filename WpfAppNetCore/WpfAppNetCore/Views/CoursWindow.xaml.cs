﻿using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;
using WpfAppNetCore.DB;
using WpfAppNetCore.ViewModels;

namespace WpfAppNetCore.Views
{
    /// <summary>
    /// Interaction logic for CoursWindow.xaml
    /// </summary>
    public partial class CoursWindow : Window
    {
        public CoursWindow()
        {
            InitializeComponent();

            DataContext = new CoursesViewModel(this);
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).mainDataGrid.ItemsSource = await StepDataBase.Context.Courses.ToListAsync();
        }
    }
}
