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
    /// Interaction logic for rCustomers.xaml
    /// </summary>
    public partial class rCustomers : Window
    {
        private Customers customer = new();
        public rCustomers()
        {
            customer = new Customers();
            InitializeComponent();
            this.DataContext = customer;
            ChargeComboCustomerType();
        }

        private void SearchIdButton_Click(object sender, RoutedEventArgs e)
        {
            var Customer = CustomersBLL.Search(Utilities.ToInt(IdTextBox.Text));

            if (Customer != null)
            {
                this.customer = Customer;
            }
            else
            {
                this.customer = new Customers();
                MessageBox.Show("This customer doesn't exist", "Doesn't exist", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            Load();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validate())
                return;

            SaveComboBox();
            var pass = CustomersBLL.Save(this.customer);
        
            if(pass)
            {
                Clear();
                MessageBox.Show("Save successful!");
            }
            else
                MessageBox.Show("The information couldn't be saved correctly...");
        
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Customers exists =  CustomersBLL.Search(this.customer.Id);

            if (CustomersBLL.Delete(this.customer.Id))
            {
                Clear();
                MessageBox.Show("The client has been eliminated successfully");
            }
            else
            {
                MessageBox.Show("There was an error in the elimination process...");
            }
        }

        private void StatusClientChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.StatusClientChoice.Items.Count > 0)
            {
                customer.Status = Utilities.ToBool(this.StatusClientChoice.SelectedValue.ToString());
            }
            else
                return;
        }

        private void ChargeComboCustomerType()
        {
            this.CustomerTypeComboBox.ItemsSource = CustomersTypesBLL.GetList(x => true);
            this.CustomerTypeComboBox.SelectedValuePath = "Id";
            this.CustomerTypeComboBox.DisplayMemberPath = "Description";

            if (CustomerTypeComboBox.Items.Count > 0)
            {
                CustomerTypeComboBox.SelectedIndex = 0;
            }
        }

        private void SaveComboBox()
        {
            customer.CustomerTypeId = CustomerTypeComboBox.SelectedValue.ToString().ToInt();
            customer.Status = Utilities.ToBool(this.StatusClientChoice.SelectedValue.ToString());
        }

        private bool Validate()
        {
            bool isValid = true;

            if (CustNameTextBox.Text.Length == 0)
            {
                isValid = false;
                MessageBox.Show("Please insert a name");
            }
            if (AdressTextBox.Text.Length == 0)
            {
                isValid = false;
                MessageBox.Show("Please insert a valid adress");
            }
            if (StatusClientChoice.SelectedItems.Count <= 0)
            {
                isValid = false;
                MessageBox.Show("Please select the status of the client");
            }
            return isValid;
        }

        private void Clear()
        {
            customer = new Customers();
            Load();
        }

        private void Load()
        {
            this.DataContext = null;
            this.DataContext = this.customer;
        }

    }
}
