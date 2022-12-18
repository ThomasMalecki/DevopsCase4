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
                DatabaseUserList = db.Query<User>(
                @"SELECT * from Users WHERE ID IN
                (SELECT ToId FROM Messages WHERE FromId = @ID OR ToId = @ID) AND
                (SELECT FromId FROM Messages WHERE FromId = @ID OR ToId = @ID) AND Id != @ID", new { ID = userid }).ToList();

                MessageUserList.ItemsSource = DatabaseUserList;
            }
        }

        public class MessagesLists
        {
            public string Name { get; set; }
            public string Content { get; set; }
        }

        public async void ReadChat()
        {
            using (IDbConnection db = UserDataContext.GetConnection())
            {
                User? selectedUser = MessageUserList.SelectedItem as User;
                if (selectedUser != null)
                {
                    List<MessagesLists> _items = new List<MessagesLists>();

                    string useride = (string)GetValue(Customers.UidProperty);
                    int userid = int.Parse(useride);

                    const string sql =
                    @"SELECT m.Content, m.Id, u.Name FROM Messages m
                    INNER JOIN Users u on m.FromId = u.Id
                    WHERE (FromId = @USERID AND ToId = @ID) OR FromId = @ID AND ToId = @USERID";


                    await db.QueryAsync<Message, User, Message>(sql, (m, u) => {
                        _items.Add(new MessagesLists{ Name = u.Name, Content = m.Content });
                        return m;
                    }, new { ID = selectedUser.Id, USERID = userid });

                    MessagesList.ItemsSource = _items;
                    ChatToId = selectedUser.Id;
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

            using (IDbConnection db = UserDataContext.GetConnection())
            {
                var userfound = db.Query<User>(@"SELECT * FROM Users WHERE Email = @EMAIL", new { EMAIL = email }).FirstOrDefault();

                string useride = (string)GetValue(Customers.UidProperty);
                int userid = int.Parse(useride);

                if (userfound != null)
                {
                    int Toid = userfound.Id;


                    db.Execute("INSERT INTO Messages(ToId, FromId, Content) Values (@TOID, @USERID, @CONTENT)",
                    new { TOID = Toid, USERID = userid, CONTENT = "Just started a conversation" });

                    db.Execute("INSERT INTO Messages(ToId, FromId, Content) Values (@TOID, @USERID, @CONTENT)",
                    new { TOID = userid, USERID = Toid, CONTENT = "Recieved your request" });

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
