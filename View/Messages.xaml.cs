using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
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


        public List<User> DatabaseUserList { get; private set; }
        public List<Message> MessageContentList { get; private set; }

        public int ChatToId;
        public void Read()
        {
            using (IDbConnection db = UserDataContext.GetConnection())
            {
                string useride = (string)GetValue(Messages.UidProperty);
                int userid = int.Parse(useride);
                MessageBox.Show("/" + userid);
                DatabaseUserList = db.Query<User>(
                @"SELECT * From Users WHERE Id IN (SELECT FromId
                FROM Messages 
                WHERE FromId = @ID OR ToId = @ID) AND Id != @ID", new { ID = userid }).ToList();

                MessageUserList.ItemsSource = DatabaseUserList;
            }
        }
        public void ReadChat()
        {
            using (IDbConnection db = UserDataContext.GetConnection())
            {
                User? selectedUser = MessageUserList.SelectedItem as User;
                if (selectedUser != null)
                {
                    MessageBox.Show("lol");

                    string useride = (string)GetValue(Customers.UidProperty);
                    int userid = int.Parse(useride);

                    MessageContentList = db.Query<Message>(
                    @"SELECT *
                    FROM Messages 
                    WHERE (FromId = @USERID AND ToId = @ID) OR FromId = @ID AND ToId = @USERID ", new { ID = selectedUser.Id, USERID = userid }).ToList();

                    MessagesList.ItemsSource = MessageContentList;
                    ChatToId = selectedUser.Id;
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
            using (IDbConnection db = UserDataContext.GetConnection())
            {
                string content = txtChatMessageBox.Text;

                string useride = (string)GetValue(Customers.UidProperty);
                int userid = int.Parse(useride);

                if (content != "") 
                {
                    db.Execute("INSERT INTO Messages(ToId, FromId, Content) Values (@CHATTOID, @USERID, @CONTENT)",
                    new { USERID = userid, CHATTOID = ChatToId, CONTENT = content });


                    MessageContentList = db.Query<Message>(
                    @"SELECT *
                    FROM Messages 
                    WHERE (FromId = @USERID AND ToId = @ID) OR FromId = @ID AND ToId = @USERID ", new { ID = ChatToId, USERID = userid }).ToList();
                    MessagesList.ItemsSource = MessageContentList;
                    txtChatMessageBox.Text = "";
                    ReadChat();
                }
            }
        }

        private void BtnSearchPersonChat_Click(object sender, RoutedEventArgs e)
        {
            string email = txtSearchPersonChat.Text;

            //using (UserDataContext context = new())
            //{
            //    bool userfound = context.Users.Any(user => user.Email == email);

            //    string useride = (string)GetValue(Customers.UidProperty);
            //    int userid = int.Parse(useride);

            //    if (userfound) {
            //        int Toid = context.Users.Where(user => user.Email == email).Select(u => u.Id).FirstOrDefault();

            //        context.Messages.Add(new Message() { ToId = userid, FromId = Toid, Content = "Just started a conversation" });
            //        context.SaveChanges();

            //        Read();
            //    }
            //    else
            //    {
            //        MessageBox.Show("User not found");
            //    }
            //}
        }
    }
}
