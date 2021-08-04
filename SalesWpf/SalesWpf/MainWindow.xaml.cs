using SalesWpf.Classes;
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

namespace SalesWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Viewer ViewerObj { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            string connectionString =
           "Data Source=(local);Initial Catalog=Sales;" +
           "Integrated Security=SSPI;Pooling=False";
            ViewerObj = new Viewer(connectionString);
            ViewerObj.SetNameTables(listNameTable);

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listNameTable.Items.Count == 0)
            {
                return;
            }
            string nameTable = "";
            ComboBoxItem selecItem = (ComboBoxItem)listNameTable.Items[listNameTable.SelectedIndex];
            nameTable = (string)selecItem.Content;
            ViewerObj.ClearListNameTable(ContentChoiceTable);
            ViewerObj.LoadNewDataTable("SELECT* FROM " + nameTable, ContentChoiceTable);
        }
    }

   
}
