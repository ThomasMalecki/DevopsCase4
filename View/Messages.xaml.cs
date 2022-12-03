using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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
    /// Interaction logic for Messages.xaml
    /// </summary>
    public partial class Messages : UserControl
    {
        public Messages()
        {
            InitializeComponent();
        }

        private List<int?> idList;

        public List<User> DatabaseUserList { get; private set; }

        public void Read()
        {

            using (UserDataContext context = new UserDataContext())
            {
                string useride = (string)GetValue(Messages.UidProperty);
                int userid = int.Parse(useride);
                idList = context.Messages.Where(x => x.FromId == userid).Select(u => u.ToId).ToList();
                DatabaseUserList = context.Users.Where(t => idList.Contains(t.Id)).ToList();
                MessageUserList.ItemsSource = DatabaseUserList;


            }
        }

        private void ucMessages_Loaded(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void MessageUserList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            using (UserDataContext context = new UserDataContext())
            {

                User? selectedUser = MessageUserList.SelectedItem as User;
                
                if (selectedUser != null)
                {
                    User? message = context.Users.Find(selectedUser.Id);
                    if (message != null)
                    {
                        
                        string useride = (string)GetValue(Customers.UidProperty);
                        int userid = int.Parse(useride);
                        
                    }
                    Read();
                }
            }
        }
    }
}
