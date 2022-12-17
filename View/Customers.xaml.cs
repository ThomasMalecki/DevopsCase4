using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml.Linq;

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
            string useride = (string)GetValue(Customers.UidProperty);
            int userid = int.Parse(useride);
            using (IDbConnection db = UserDataContext.GetConnection())
            {

                DatabaseCustomers = db.Query<Customer>(
                @"SELECT *
                FROM Customers 
                WHERE UserId = @ID LIMIT 4", new { ID = userid }).ToList();


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
            if (btnAddCustomerAdd.Content == "Add")
            {
                using (IDbConnection db = UserDataContext.GetConnection())
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
                        string useride = (string)GetValue(Customers.UidProperty);
                        int userid = int.Parse(useride);

                        db.Execute("INSERT INTO Customers(Name,LastName,City,Country,Email,HouseNr,Province,Street, userId) Values (@NAME, @LASTNAME, @CITY, @COUNTRY, @EMAIL, @HOUSENR, @PROVINCE, @STREET, @USERID)",
                        new { NAME = name, LASTNAME = lastName, CITY = city, COUNTRY = country, EMAIL = email, HOUSENR = houseNr, PROVINCE = province, STREET = street, USERID = userid });

                        db.Execute("INSERT INTO Logs (UserId, Description, Action, Timestamp) VALUES (@USERID, @DESCRIPTION, @ACTION, @TIMESTAMP)",
                        new { USERID = userid, DESCRIPTION = "Customer " + name + " " + lastName + " was created.", ACTION = "PlusBox", TIMESTAMP = DateTime.Now.ToString("d-M-yyyy - HH:mm") });
                    }
                    CustomerList.Visibility = Visibility.Visible;
                    addCustomersField.Visibility = Visibility.Collapsed;
                    AddcustomerClear();
                    Read();
                }
            }
            if(btnAddCustomerAdd.Content == "Edit")
            {
                using (IDbConnection db = UserDataContext.GetConnection())
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

                    if (name != "" && lastName != "" && email != "" && selectedCustomer != null)
                    {

                        string useride = (string)GetValue(Customers.UidProperty);
                        int userid = int.Parse(useride);
                        db.Execute("UPDATE Customers SET Name = @NAME, LastName = @LASTNAME, City = @CITY, Country = @COUNTRY, Email = @EMAIL, HouseNr = @HOUSENR, Province = @PROVINCE, Street = @STREET WHERE Id = @CUSTOMERID",
                        new { NAME = name, LASTNAME = lastName, CITY = city, COUNTRY = country, EMAIL = email, HOUSENR = houseNr, PROVINCE = province, STREET = street, CUSTOMERID = selectedCustomer.Id });
                        db.Execute("INSERT INTO Logs (UserId, Description, Action, Timestamp) VALUES (@USERID, @DESCRIPTION, @ACTION, @TIMESTAMP)",
                        new { USERID = userid , DESCRIPTION = "Customer " + name + " " + lastName + " was modfied." , ACTION = "PencilBox", TIMESTAMP = DateTime.Now.ToString("d-M-yyyy - HH:mm") });
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

        private void btnCustomerEdit_Click(object sender, RoutedEventArgs e)
        {
            btnAddCustomerAdd.Content = "Edit";
            CustomerList.Visibility = Visibility.Collapsed;
            addCustomersField.Visibility = Visibility.Visible;
            using (IDbConnection db = UserDataContext.GetConnection())
            {
                Customer? selectedCustomer = CustomerList.SelectedItem as Customer;
                if (selectedCustomer != null)
                {

                    Customer? result = db.Query<Customer>(
                    @"SELECT *
                    FROM Customers  
                    WHERE Id = @ID", new { ID = selectedCustomer.Id }).FirstOrDefault();
                    if (result != null)
                    {
                        txtAddCustomerName.Text = result.Name;
                        txtAddCustomerLastName.Text = result.LastName;
                        txtAddCity.Text = result.City;
                        txtAddCountry.Text = result.Country;
                        txtAddCustomerEmail.Text = result.Email;
                        txtAddHouseNr.Text = result.HouseNr;
                        txtAddProvince.Text = result.Province;
                        txtAddStreet.Text = result.Street;
                    }
                }
            }

        }

        private void btnCustomerDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Would you like to remove this user?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                using (IDbConnection db = UserDataContext.GetConnection())
                {
                    Customer? selectedCustomer = CustomerList.SelectedItem as Customer;
                    if (selectedCustomer != null)
                    {
                        string useride = (string)GetValue(Customers.UidProperty);
                        int userid = int.Parse(useride);
                        db.Execute("DELETE FROM Customers WHERE id = @ID", new { ID = selectedCustomer.Id });
                        db.Execute("INSERT INTO Logs (UserId, Description, Action, Timestamp) VALUES (@USERID, @DESCRIPTION, @ACTION, @TIMESTAMP)",
                        new { USERID = userid, DESCRIPTION = "Customer " + selectedCustomer.Name + " " + selectedCustomer.LastName + " was removed.", ACTION = "MinusBox", TIMESTAMP = DateTime.Now.ToString("d-M-yyyy - HH:mm") });
                        Read();
                    }
                }
            }
            
        }
    }
}
