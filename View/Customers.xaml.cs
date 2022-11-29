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

namespace DevopsCase4.View
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : UserControl
    {
        public Customers()
        {
            InitializeComponent();
        }

        public List<Customer> DatabaseCustomers { get; private set; }

        public void Read()
        {
            using (UserDataContext context = new UserDataContext())
            {
                DatabaseCustomers = context.Customers.ToList();
                CustomerList.ItemsSource = DatabaseCustomers;
            }
        }

        private void ucCustomers_Loaded(object sender, RoutedEventArgs e)
        {
            Read();
        }
    }
}
