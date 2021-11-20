using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using NorthwindDB;

namespace NorthwindWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NorthwindContext db;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            db = new NorthwindContext();
            
            db.Orders.ToList().ForEach(x => OrderBox.Items.Add(new ComboBoxItem().Content = x));
        }

        private void OrderBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedOrder = (Order) OrderBox.SelectedItem;

            OrderDetailList.ItemsSource = db.OrderDetails
                .Include(x => x.Product.Supplier)
                .Include(x => x.Product.Category)
                .Include(x => x.Order.Employee)
                .Where(x => x.Order.Equals(selectedOrder))
                .ToList();
        }
    }
}