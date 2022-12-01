using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
            string useride = (string)GetValue(Dashboard.UidProperty);
            int userid = int.Parse(useride);
            using (UserDataContext context = new UserDataContext())
            {
                DatabaseCustomers = context.Customers.Where(user => user.userId == userid).ToList();
                
                CustomerList.ItemsSource = DatabaseCustomers;
                
            }
        }

        private void ucCustomers_Loaded(object sender, RoutedEventArgs e)
        {
            Read();
        }
        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            btnAddCustomerAdd.Content = "Add";
            CustomerList.Visibility = Visibility.Collapsed;
            addCustomersField.Visibility = Visibility.Visible;
        }

        private void AddcustomerClear()
        {
            txtAddCustomerName.Clear();
            txtAddCity.Clear();
            txtAddCountry.Clear();
            txtAddCustomerEmail.Clear();
            txtAddCustomerLastName.Clear();
            txtAddHouseNr.Clear();
            txtAddProvince.Clear();
            txtAddStreet.Clear();
        }
        private void btnAddCustomerAdd_Click(object sender, RoutedEventArgs e)
        {
            if(btnAddCustomerAdd.Content == "Add")
            {
                using (UserDataContext context = new UserDataContext())
                {
                    
                    var name = txtAddCustomerName.Text;
                    var lastName = txtAddCustomerLastName.Text;
                    var city = txtAddCity.Text;
                    var country = txtAddCountry.Text;
                    var email = txtAddCustomerEmail.Text;
                    var houseNr = txtAddHouseNr.Text;
                    var province = txtAddProvince.Text;
                    var street = txtAddStreet.Text;

                    if (name != "" && lastName != "" && email != "")
                    {
                        string useride = (string)GetValue(Dashboard.UidProperty);
                        int userid = int.Parse(useride);
                        context.Customers.Add(new Customer() { Name = name, LastName = lastName, Email = email, Country = country, Province = province, Street = street, HouseNr = houseNr, City = city, userId=userid});
                        context.SaveChanges();
                        Read();
                    }
                    CustomerList.Visibility = Visibility.Visible;
                    addCustomersField.Visibility = Visibility.Collapsed;
                    AddcustomerClear();
                }
            }
            if(btnAddCustomerAdd.Content == "Edit")
            {
                using (UserDataContext context = new UserDataContext())
                {
                    Customer? selectedCustomer = CustomerList.SelectedItem as Customer;

                    var name = txtAddCustomerName.Text;
                    var lastName = txtAddCustomerLastName.Text;
                    var city = txtAddCity.Text;
                    var country = txtAddCountry.Text;
                    var email = txtAddCustomerEmail.Text;
                    var houseNr = txtAddHouseNr.Text;
                    var province = txtAddProvince.Text;
                    var street = txtAddStreet.Text;

                    if (name != null && lastName != null && email != null && selectedCustomer != null)
                    {

                        Customer? customer = context.Customers.Find(selectedCustomer.Id);
                        if (customer != null)
                        {
                            customer.Name = name;
                            customer.LastName = lastName;
                            customer.City = city;
                            customer.Country = country;
                            customer.Email = email;
                            customer.HouseNr = houseNr;
                            customer.Province = province;
                            customer.Street = street;

                            context.SaveChanges();
                        }
                        CustomerList.Visibility = Visibility.Visible;
                        addCustomersField.Visibility = Visibility.Collapsed;
                        AddcustomerClear();
                        Read();
                    }
                }
            }
        }

        private void btnAddCustomerCancel_Click(object sender, RoutedEventArgs e)
        {
            CustomerList.Visibility = Visibility.Visible;
            addCustomersField.Visibility = Visibility.Collapsed;
            AddcustomerClear();
            
        }

        private void btnCustomerDelete_Click(object sender, RoutedEventArgs e)
        {
            using (UserDataContext context = new UserDataContext())
            {
                Customer? selectedCustomer = CustomerList.SelectedItem as Customer;

                if(selectedCustomer != null )
                {
                        
                    Customer? customer = context.Customers.Find(selectedCustomer.Id);
                    if(customer != null)
                    {
                        context.Remove(customer);
                        context.SaveChanges();
                    }
                    Read();
                }
            }
        }

        private void btnCustomerEdit_Click(object sender, RoutedEventArgs e)
        {
            btnAddCustomerAdd.Content = "Edit";
            CustomerList.Visibility = Visibility.Collapsed;
            addCustomersField.Visibility = Visibility.Visible;
            using (UserDataContext context = new UserDataContext())
            {
                Customer? selectedCustomer = CustomerList.SelectedItem as Customer;
                if(selectedCustomer != null)
                {

                    Customer? customer = context.Customers.Find(selectedCustomer.Id);
                    if (customer != null)
                    {
                        txtAddCustomerName.Text = customer.Name;
                        txtAddCustomerLastName.Text = customer.LastName;
                        txtAddCity.Text = customer.City;
                        txtAddCountry.Text = customer.Country;
                        txtAddCustomerEmail.Text = customer.Email;
                        txtAddHouseNr.Text = customer.HouseNr;
                        txtAddProvince.Text = customer.Province;
                        txtAddStreet.Text = customer.Street;

                        context.SaveChanges();
                    }
                }
            }

        }
    }
}
