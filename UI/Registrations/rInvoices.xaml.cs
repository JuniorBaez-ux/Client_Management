using Client_Management.Models;
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
        public rInvoices()
        {
            invoiceDetail = new();
            InitializeComponent();
            this.DataContext = invoiceDetail;
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
            Load();
        }

        private void Load()
        {
            this.DataContext = null;
            this.DataContext = this.invoiceDetail;
        }
    }
}
