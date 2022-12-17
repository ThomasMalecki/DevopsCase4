using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
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

        private void UcDashboard_MouseMove(object sender, MouseEventArgs e)
        {
            txtDashboardTime.Text = DateTime.Now.ToString("HH:mm");
            Read();
        }

        public void Read()
        {
            string useride = (string)GetValue(Dashboard.UidProperty);
            int userid = int.Parse(useride);
            using (IDbConnection db = UserDataContext.GetConnection())
            {
                DatabaseLogs = db.Query<Log>(
                            @"SELECT Action, Timestamp, Description
                            FROM Logs 
                            WHERE UserId = @ID LIMIT 4", new { ID = userid}).ToList();


                if (DatabaseLogs.Count() > 0) {
                    ActivityList.ItemsSource = DatabaseLogs;
                }

            }
        }   

        private void UcDashboard_Loaded(object sender, RoutedEventArgs e)
        {
            Read();
        }
    }
}
