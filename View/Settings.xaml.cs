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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace DevopsCase4.View
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        

        public Settings()
        {
            InitializeComponent();

        }

        private void ShowUserInfo()
        {
            using (IDbConnection db = UserDataContext.GetConnection())
            {
                string useride = (string)GetValue(Settings.UidProperty);
                int userid = int.Parse(useride);
                User? result = db.Query<User>(
                    @"SELECT *
                    FROM Users  
                    WHERE Id = @ID", new { ID = useride }).FirstOrDefault();
                if (result != null)
                {
                    txtChangeName.Text = result.Name;
                    txtChangeLastName.Text = result.LastName;
                    txtChangeCity.Text = result.City;
                    txtChangeCountry.Text = result.Country;
                    txtChangeEmail.Text = result.Email;
                    txtChangeHouseNr.Text = result.HouseNr;
                    txtChangeProvince.Text = result.Province;
                    txtChangeStreet.Text = result.Street;
                }   
            }
        }

        private void UcSettings_Loaded(object sender, RoutedEventArgs e)
        {
            ShowUserInfo();
        }

        private void BtnUserEditCancel_Click(object sender, RoutedEventArgs e)
        {
            ShowUserInfo();
        }

        private void BtnUserEdit_Click(object sender, RoutedEventArgs e)
        {
            using (IDbConnection db = UserDataContext.GetConnection())
            {
                string useride = (string)GetValue(Settings.UidProperty);
                int userid = int.Parse(useride);
                var emailfound = db.Query<User>(@"SELECT * FROM Users WHERE Email = @EMAIL", new { EMAIL = (txtChangeEmail.Text).ToLower() }).FirstOrDefault();
                if (emailfound != null)
                {
                    db.Execute("UPDATE Users SET Name = @NAME, LastName = @LASTNAME, City = @CITY, Country = @COUNTRY, Email = @EMAIL, HouseNr = @HOUSENR, Province = @PROVINCE, Street = @STREET WHERE Id = @USERID",
                    new { NAME = txtChangeName.Text, LASTNAME = txtChangeLastName.Text, CITY = txtChangeCity.Text, COUNTRY = txtChangeCountry.Text, EMAIL = (txtChangeEmail.Text).ToLower(), HOUSENR = txtChangeHouseNr.Text, PROVINCE = txtChangeProvince.Text, STREET = txtChangeStreet.Text, USERID = userid });
                    ShowUserInfo();
                }
                if (emailfound != null)
                {
                    MessageBox.Show("Your account credentials were succesfully modified."); ShowUserInfo();
                    db.Execute("INSERT INTO Logs (UserId, Description, Action, Timestamp) VALUES (@USERID, @DESCRIPTION, @ACTION, @TIMESTAMP)",
                    new { USERID = userid, DESCRIPTION = "Account settings / credentials were modified.", ACTION = "PencilBox", TIMESTAMP = DateTime.Now.ToString("d-M-yyyy - HH:mm") });
                }
                else
                {
                    MessageBox.Show("Your account credentials were modified except: email -> already in use.");
                    db.Execute("INSERT INTO Logs (UserId, Description, Action, Timestamp) VALUES (@USERID, @DESCRIPTION, @ACTION, @TIMESTAMP)",
                    new { USERID = userid, DESCRIPTION = "Account credentials not modified: Email already in use.", ACTION = "PencilBox", TIMESTAMP = DateTime.Now.ToString("d-M-yyyy - HH:mm") });
                }



            }
        }
    }
}
