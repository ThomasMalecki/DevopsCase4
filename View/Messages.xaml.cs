using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
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
    /// Interaction logic for Messages.xaml
    /// </summary>
    public partial class Messages : UserControl
    {
        public Messages()
        {
            InitializeComponent();
        }

        private List<int?> idList;
        private List<int?> idList2;

        public List<User> DatabaseUserList { get; private set; }
        public List<Message> MessageContentList { get; private set; }

        public int ChatToId;
        public void Read()
        {
            using (UserDataContext context = new())
            {
                string useride = (string)GetValue(Messages.UidProperty);
                int userid = int.Parse(useride);
                idList = context.Messages.Where(x => x.FromId == userid).Select(u => u.ToId).ToList();
                idList2 = context.Messages.Where(x => x.ToId == userid).Select(u => u.FromId).ToList();
                idList2.ForEach(item => idList.Add(item));
                DatabaseUserList = context.Users.Where(t => idList.Contains(t.Id)).ToList();
                MessageUserList.ItemsSource = DatabaseUserList;
            }
        }
        public void ReadChat()
        {
            using (UserDataContext context = new())
            {

                User? selectedUser = MessageUserList.SelectedItem as User;

                if (selectedUser != null)
                {
                    
                    User? message = context.Users.Find(selectedUser.Id);
                    if (message != null)
                    {
                        
                        string useride = (string)GetValue(Customers.UidProperty);
                        int userid = int.Parse(useride);

                        MessageContentList = context.Messages.Where(id => id.FromId == userid && id.ToId == message.Id || id.FromId == message.Id && id.ToId == userid).ToList();

                        MessagesList.ItemsSource = MessageContentList;
                        ChatToId = message.Id;
                    }
                    Read();
                }
            }
        }
        private void UcMessages_Loaded(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void MessageUserList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ReadChat();
        }

        private void BtnChatSend_Click(object sender, RoutedEventArgs e)
        {
            using (UserDataContext context = new())
            {
                string content = txtChatMessageBox.Text;

                string useride = (string)GetValue(Customers.UidProperty);
                int userid = int.Parse(useride);

                if (content != "" )
                {
                    context.Messages.Add(new Message() { ToId = userid, FromId = ChatToId, Content = content});
                    context.SaveChanges();
                    
                    MessageContentList = context.Messages.Where(id => id.FromId == userid && id.ToId == ChatToId || id.FromId == ChatToId && id.ToId == userid).ToList();

                    MessagesList.ItemsSource = MessageContentList;
                    txtChatMessageBox.Text = "";
                    ReadChat();
                }
            }
        }

        private void BtnSearchPersonChat_Click(object sender, RoutedEventArgs e)
        {
            string email = txtSearchPersonChat.Text;

            using (UserDataContext context = new())
            {
                bool userfound = context.Users.Any(user => user.Email == email);

                string useride = (string)GetValue(Customers.UidProperty);
                int userid = int.Parse(useride);

                if (userfound) {
                    int Toid = context.Users.Where(user => user.Email == email).Select(u => u.Id).FirstOrDefault();

                    context.Messages.Add(new Message() { ToId = userid, FromId = Toid, Content = "Just started a conversation" });
                    context.SaveChanges();

                    Read();
                }
                else
                {
                    MessageBox.Show("User not found");
                }
            }
        }
    }
}
