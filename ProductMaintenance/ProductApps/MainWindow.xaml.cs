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

namespace ProductApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product cProduct;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            decimal myTotalPayment;
            try
            {
                cProduct = new Product(Convert.ToDecimal(priceTextBox.Text), Convert.ToInt16(quantityTextBox.Text));
                cProduct.calTotalPayment();
                //Total Charge After GST@10% =  (Total payment + $25.00 + $5.00) * 1.1
                myTotalPayment = (cProduct.TotalPayment) + 25.00m;
                tbDeliveryCharges.Text = myTotalPayment.ToString();
                //Add wrapping cost
                myTotalPayment = myTotalPayment + 5.00m;
                tbwrappingCost.Text = myTotalPayment.ToString();
                //Add GST
                myTotalPayment = myTotalPayment * 1.1m;
                tbGST.Text = myTotalPayment.ToString();
                totalPaymentTextBlock.Text = myTotalPayment.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter data again", "Data Entry Error");
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            productTextBox.Text = "";
            priceTextBox.Text = "";
            quantityTextBox.Text = "";
            totalPaymentTextBlock.Text = "";
            //Clear new Textblock 
            tbGST.Text = "";
            tbDeliveryCharges.Text = "";
            tbwrappingCost.Text = "";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
