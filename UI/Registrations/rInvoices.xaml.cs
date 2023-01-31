using Client_Management.BLL;
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
    /// Interaction logic for rInvoices.xaml
    /// </summary>
    public partial class rInvoices : Window
    {
        private InvoiceDetail invoiceDetail = new();
        private Invoice invoice = new();
        public rInvoices()
        {
            invoiceDetail = new();
            InitializeComponent();
            this.DataContext = invoiceDetail;
            ChargeComboBoxCostumer();
        }

        private void SearchIdButton_Click(object sender, RoutedEventArgs e)
        {
            var InvoiceDetail = InvoicesDetailBLL.Search(Utilities.ToInt(IdTextBox.Text));

            var Invoice = InvoicesBLL.Search(Utilities.ToInt(InvoiceDetail.CustomerId.Id));

            if (Invoice != null && InvoiceDetail != null)
            {
                this.invoice = Invoice;
                this.invoiceDetail = InvoiceDetail;
            }
            else
            {
                this.invoice = new();
                this.invoiceDetail = new();
                MessageBox.Show("This invoice doesn't exist", "Doesn't exist", MessageBoxButton.OK, MessageBoxImage.Information);
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
            var pass = InvoicesDetailBLL.Save(this.invoiceDetail);

            if (pass)
            {
                Clear();
                MessageBox.Show("Save successful!");
            }
            else
                MessageBox.Show("The information couldn't be saved correctly...");

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            InvoiceDetail exists = InvoicesDetailBLL.Search(this.invoiceDetail.Id);

            if (InvoicesDetailBLL.Delete(this.invoiceDetail.Id, this.invoiceDetail.CustomerId.Id))
            {
                Clear();
                MessageBox.Show("The invoice has been eliminated successfully");
            }
            else
            {
                MessageBox.Show("There was an error in the elimination process...");
            }
        }

        private void ChargeComboBoxCostumer() {
            this.CustomerIdComboBox.ItemsSource = CustomersBLL.GetList(x => true);
            this.CustomerIdComboBox.SelectedValuePath = "Id";
            this.CustomerIdComboBox.DisplayMemberPath = "CustName";

            if (CustomerIdComboBox.Items.Count > 0)
            {
                CustomerIdComboBox.SelectedIndex = 0;
            }
        }

        private void DatosDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculateTotals();
        }
        private void DatosDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            CalculateTotals();
        }
        private void ChargeComboCustomer(object sender, SelectionChangedEventArgs e)
        {
            this.CustomerIdComboBox.ItemsSource = CustomersBLL.GetList(x => true);
            this.CustomerIdComboBox.SelectedValuePath = "Id";
            this.CustomerIdComboBox.DisplayMemberPath = "CustName";

            if (CustomerIdComboBox.Items.Count > 0)
            {
                CustomerIdComboBox.SelectedIndex = 0;
            }
        }

        private void SaveComboBox()
        {
            invoice.CustomerId = CustomerIdComboBox.SelectedValue.ToInt();
        }

        private void CalculateTotals() {

            invoice.CustomerId = Utilities.ToInt(CustomerIdComboBox.SelectedValue);

            var quantity = invoiceDetail.Qty = Utilities.ToInt(QuantityGrid.Binding);

            var price = invoiceDetail.Price= Utilities.ToDouble(PriceGrid.Binding);

            //ITBIS in Dominican Republic is an 18% of the purchase of the product
            var totalItbis = invoiceDetail.Totalitbis = quantity * price * 0.18;

            var subtotal = invoiceDetail.SubTotal = quantity * price;

            var total = invoiceDetail.Total = subtotal + totalItbis;

            invoice.Totalitbis = totalItbis;
            invoice.SubTotal = subtotal;
            invoice.Total = total;

            invoiceDetail.CustomerId = invoice;
        }

        private bool Validate()
        {
            bool isValid = true;

            if (CustomerIdComboBox.Text.Length == 0)
            {
                isValid = false;
                MessageBox.Show("Please insert a name");
            }
            if (TotalitbisTextBox.Text.Length == 0)
            {
                isValid = false;
                MessageBox.Show("Please fill in the information in the detail below");
            }
            if (SubTotalTextBox.Text.Length == 0)
            {
                isValid = false;
                MessageBox.Show("Please fill in the information in the detail below");
            }
            if (TotalTextBox.Text.Length == 0)
            {
                isValid = false;
                MessageBox.Show("Please fill in the information in the detail below");
            }
            return isValid;
        }

        private void Clear()
        {
            invoiceDetail = new();
            invoice = new();
            Load();
        }

        private void Load()
        {
            this.DataContext = null;
            this.DataContext = this.invoiceDetail;
        }

    }
}
