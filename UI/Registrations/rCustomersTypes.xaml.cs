using Client_Management.Models;
using Proyecto_FInal_Administracion_De_Sistemas.BLL;
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

namespace Client_Management.UI.Registrations
{
    /// <summary>
    /// Interaction logic for rCustomersTypes.xaml
    /// </summary>
    public partial class rCustomersTypes : Window
    {
        private CustomerTypes customerTypes = new();
        public rCustomersTypes()
        {
            customerTypes = new();
            InitializeComponent();
            this.DataContext = customerTypes;
        }

        private void SearchIdButton_Click(object sender, RoutedEventArgs e)
        {
            var CustomerType = CustomersTypesBLL.Search(Utilities.ToInt(IdTextBox.Text));

            if (CustomerType != null)
            {
                this.customerTypes = CustomerType;
            }
            else
            {
                this.customerTypes = new();
                MessageBox.Show("This customer type doesn't exist", "Doesn't exist", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            Load();
        }
        private bool Validate()
        {
            bool isValid = true;

            if (DescriptionTextBox.Text.Length == 0)
            {
                isValid = false;
                MessageBox.Show("Please insert the description");
            }
            return isValid;
        }

        private void Clear()
        {
            customerTypes = new CustomerTypes();
            Load();
        }

        private void Load()
        {
            this.DataContext = null;
            this.DataContext = this.customerTypes;
        }

        private void DeleteButton_Click_1(object sender, RoutedEventArgs e)
        {
            CustomerTypes exists = CustomersTypesBLL.Search(this.customerTypes.Id);

            if (CustomersTypesBLL.Delete(this.customerTypes.Id))
            {
                Clear();
                MessageBox.Show("The customer type has been eliminated successfully");
            }
            else
            {
                MessageBox.Show("There was an error in the elimination process...");
            }
        }

        private void SaveButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (!Validate())
                return;

            var pass = CustomersTypesBLL.Save(this.customerTypes);

            if (pass)
            {
                Clear();
                MessageBox.Show("Save successful!");
            }
            else
                MessageBox.Show("The information couldn't be saved correctly...");
        }

        private void NewButton_Click_1(object sender, RoutedEventArgs e)
        {
            Clear();
        }
    }
}
