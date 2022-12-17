using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.IO;
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
using System.Xml.Linq;

namespace DevopsCase4.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public int loginId;
        public LoginView()
        {
            InitializeComponent();
            btnLogin.Content = "LOG IN";
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton==MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var email = (txtUser.Text).ToLower();
            var Password = txtPass.Password;

            if (btnLogin.Content == "LOG IN")
            {
                
                if(email != "" && Password != "")
                {
                    using (IDbConnection db = UserDataContext.GetConnection())
                    {
                        User? result = db.Query<User>(
                            @"select Email, Password, Id
                            FROM Users 
                            WHERE Password = @PASSWORD AND Email = @EMAIL", new { PASSWORD = Password, EMAIL = email }).FirstOrDefault();
                        if (result != null)
                        {
                            loginId = result.Id;
                            MessageBox.Show(result.Id + "");

                            GrantAccess();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect username or password.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("You must fill in both fields.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
            else
            {

                if (email != "" && Password != "")
                {
                    using (IDbConnection db = UserDataContext.GetConnection())
                    {
                        User? result = db.Query<User>(
                            @"select Email, Password
                            FROM Users 
                            WHERE Password = @PASSWORD AND Email = @EMAIL", new { PASSWORD = Password, EMAIL = email }).FirstOrDefault();
                        if (result == null)
                        {
                            db.Execute("INSERT INTO Users(email, Password) " +
                            "VALUES (@EMAIL,@PASSWORD)", new { PASSWORD = Password, EMAIL = email });
                            result = db.Query<User>(
                            @"select Email, Password, Id 
                            FROM Users 
                            WHERE Password = @PASSWORD AND Email = @EMAIL", new { PASSWORD = Password, EMAIL = email }).FirstOrDefault();
                            loginId = result.Id;
                            GrantAccess();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("User already exists.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("You must fill in both fields.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
        }
        public void GrantAccess()
        {
            DashboardView dashboard = new(loginId);
            dashboard.Show();
        }


        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            

            if (btnLogin.Content != "LOG IN")
            {

                TxtNewUser.Text = "New user?";
                BtnRegister.Content = "Register";
                TxtLogin.Text = "Login";
                btnLogin.Content = "LOG IN";
            }
            else
            {
                TxtNewUser.Text = "Already have an account?";
                BtnRegister.Content = "Login";
                TxtLogin.Text = "Register";
                btnLogin.Content = "REGISTER";
            }
        }
    }
}
