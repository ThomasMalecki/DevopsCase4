using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        public List<Log> DatabaseLogs { get; private set; }

        public Dashboard()
        {
            InitializeComponent();
            
        }

        private void ucDashboard_MouseMove(object sender, MouseEventArgs e)
        {
            txtDashboardTime.Text = DateTime.Now.ToString("HH:mm");
            Read();
        }

        public void Read()
        {
            string useride = (string)GetValue(Dashboard.UidProperty);
            int userid = int.Parse(useride);
            using (UserDataContext context = new UserDataContext())
            {
                DatabaseLogs = context.Logs.Where(log => log.UserId == userid).OrderByDescending(x => x.Id).Take(4).ToList();

                ActivityList.ItemsSource = DatabaseLogs;


            }
        }

        private void ucDashboard_Loaded(object sender, RoutedEventArgs e)
        {
            Read();
        }
    }
}
