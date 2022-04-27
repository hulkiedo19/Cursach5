using Cursach5.Models;
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

namespace Cursach5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void SubjectGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        //{
        //    if(e.NewItem == null)
        //    {
        //        return;
        //    } else
        //    {
        //        MessageBox.Show(e.ToString(), "adding new item");
        //    }
        //}

        //private void SubjectGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        //{
        //    if(e.EditAction == DataGridEditAction.Cancel)
        //    {
        //        return;
        //    }
            
        //    if(e.EditAction == DataGridEditAction.Commit)
        //    {
        //        //var elem = e.Row.Item;

        //        //using(var DbContext = new DatabaseEntities())
        //        //{
        //        //    DbContext.Subjects.Add(elem as Subject);
        //        //    DbContext.SaveChanges();
        //        //}
        //    }
        //}

        //private void Update_Click(object sender, RoutedEventArgs e)
        //{
        //    SubjectGrid.Items.Refresh();
        //}
    }
}
