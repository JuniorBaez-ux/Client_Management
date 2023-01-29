using Client_Management.UI.Registrations;
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

namespace Client_Management
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

        private void ClientsRegistry_Click(object sender, RoutedEventArgs e)
        {

            rCustomers rCustomers = new();
            rCustomers.Show();
        }

        private void ClientsTypesRegistry_Click(object sender, RoutedEventArgs e)
        {
            rCustomersTypes rCustomersTypes = new();
            rCustomersTypes.Show();
        }

        private void InvoicesRegistry_Click(object sender, RoutedEventArgs e)
        {
            rInvoices rInvoices = new();
            rInvoices.Show();
        }
    }
}
