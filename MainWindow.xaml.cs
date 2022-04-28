using Magazyn.Context;
using System.Windows;
using System.Windows.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Magazyn.Entities;
using System.Linq;
using System.Collections.ObjectModel;

namespace Magazyn
{

    public partial class MainWindow : Window
    {

        private readonly ToolContext context = new ToolContext();
        private CollectionViewSource categoryToolsViewSource;
        
        public MainWindow()
        {
            InitializeComponent();
            categoryToolsViewSource =
                (CollectionViewSource)FindResource(nameof(categoryToolsViewSource));

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context.Database.EnsureCreated();
            context.Tools.Load();
            context.Categories.Load();

            categoryToolsViewSource.Source =
                context.Tools.Local.ToObservableCollection();

            ObservableCollection<Category> categories = context.Categories.Local.ToObservableCollection();
            categoryName.ItemsSource = categories;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            context.SaveChanges();
            toolsDataGrid.Items.Refresh();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // clean up database connections
            context.Dispose();
            base.OnClosing(e);
        }

        private void DrillButton_Click(object sender, RoutedEventArgs e)
        {
            //Category selectedCategory = categoryDataGrid.SelectedItem as Category;
            //MessageBox.Show(selectedCategory.CategoryName.ToString());
        }
            
    }
}
