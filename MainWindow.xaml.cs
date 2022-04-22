using Magazyn.Context;
using System.Windows;
using System.Windows.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Magazyn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly ToolContext context = new ToolContext();
        private CollectionViewSource categoryViewSource;
        public MainWindow()
        {
            InitializeComponent();
            categoryViewSource =
                (CollectionViewSource)FindResource(nameof(categoryViewSource));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context.Database.EnsureCreated();
            context.Categories.Load();
            categoryViewSource.Source =
                context.Categories.Local.ToObservableCollection();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // all changes are automatically tracked, including
            // deletes!
            context.SaveChanges();

            // this forces the grid to refresh to latest values
            categoryDataGrid.Items.Refresh();
            toolsDataGrid.Items.Refresh();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // clean up database connections
            context.Dispose();
            base.OnClosing(e);
        }
    }
}
