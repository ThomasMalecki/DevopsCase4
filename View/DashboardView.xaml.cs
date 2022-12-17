using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

namespace DevopsCase4.View
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : Window
    {
        public int userid;
        public DashboardView(int loginid)
        {
            InitializeComponent();
            userid = loginid;
            dashboard.Uid = userid.ToString();
            customers.Uid = userid.ToString();
            messages.Uid = userid.ToString();
            settings.Uid = userid.ToString();

            using (IDbConnection db = UserDataContext.GetConnection())
            {
                User? result = db.Query<User>(
                @"select Name, LastName
                FROM Users 
                WHERE Id = @ID", new { ID = userid}).FirstOrDefault();
                if(result != null) {
                    if (result.Name == null || result.LastName == null)
                    {
                        MessageBoxResult message = MessageBox.Show("Your Credentials need to be completed. Want to complete them now?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (message == MessageBoxResult.Yes)
                        {
                            SetActiveUserControl(settings, BtnSettings);
                        }
                    }
                }

            }
            ReloadInfo();


        }
        public void ReloadInfo()
        {
            using (IDbConnection db = UserDataContext.GetConnection())
            {
                User? result = db.Query<User>(
                @"select Name, LastName
                FROM Users 
                WHERE Id = @ID", new { ID = userid }).FirstOrDefault();
                if (result != null)
                {
                    txtNavigationUserName.Text = result.Name + " " + result.LastName;
                }
            }
        }
        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Would you like to logout?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if(result == MessageBoxResult.Yes)
            {
                Logout();
                Close();
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }

        }
        public static void Logout()
        {
            LoginView login = new();
            login.Show();
        }

        private bool IsMaximized = false;



        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            Logout();
            Close();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximized = true;
                }
            }
        }

        private void BtnDashboard_Click(object sender, RoutedEventArgs e)
        {
            SetActiveUserControl(dashboard, BtnDashboard);
        }

        public void SetActiveUserControl (UserControl control, Button button)
        {
            dashboard.Visibility= Visibility.Collapsed;
            customers.Visibility = Visibility.Collapsed;
            messages.Visibility = Visibility.Collapsed;
            settings.Visibility = Visibility.Collapsed;
            BtnDashboard.Background = null;
            BtnCustomers.Background = null;
            BtnMessages.Background = null;
            BtnSettings.Background = null;
            control.Visibility= Visibility.Visible;
            button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF523AD0"));
        }

        private void BtnCustomers_Click(object sender, RoutedEventArgs e)
        {
            SetActiveUserControl(customers ,BtnCustomers);
            ReloadInfo();
        }

        private void BtnMessages_Click(object sender, RoutedEventArgs e)
        {
            SetActiveUserControl(messages, BtnMessages);
            ReloadInfo();
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            SetActiveUserControl(settings, BtnSettings);
            ReloadInfo();
        }
    }
}
