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
            using (UserDataContext context = new UserDataContext())
            {
                txtNavigationUserName.Text = context.Users.Where(user => user.Id == userid).Select(u => u.Email).FirstOrDefault();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
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
        public void Logout()
        {
            LoginView login = new();
            login.Show();
        }

        private bool IsMaximized = false;

        private void btnLogout_Click(object sender, RoutedEventArgs e)
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
            SetActiveUserControl(dashboard);
            BtnDashboard.Background= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF523AD0"));
        }

        public void SetActiveUserControl (UserControl control)
        {
            dashboard.Visibility= Visibility.Collapsed;
            customers.Visibility = Visibility.Collapsed;
            BtnDashboard.Background = null;
            BtnCustomers.Background = null;
            control.Visibility= Visibility.Visible;
        }

        private void BtnCustomers_Click(object sender, RoutedEventArgs e)
        {
            SetActiveUserControl(customers);
            BtnCustomers.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF523AD0"));
        }
    }
}
