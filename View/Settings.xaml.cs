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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            using (UserDataContext context = new UserDataContext())
            {
                string useride = (string)GetValue(Settings.UidProperty);
                int userid = int.Parse(useride);
                User? user = context.Users.Find(userid);
                if (user != null)
                {
                    txtChangeName.Text = user.Name;
                    txtChangeLastName.Text = user.LastName;
                    txtChangeCity.Text = user.City;
                    txtChangeCountry.Text = user.Country;
                    txtChangeEmail.Text = user.Email;
                    txtChangeHouseNr.Text = user.HouseNr;
                    txtChangeProvince.Text = user.Province;
                    txtChangeStreet.Text = user.Street;
                    context.SaveChanges();
                }
            }
        }

        private void ucSettings_Loaded(object sender, RoutedEventArgs e)
        {
            ShowUserInfo();
        }

        private void BtnUserEditCancel_Click(object sender, RoutedEventArgs e)
        {
            ShowUserInfo();
        }

        private void BtnUserEdit_Click(object sender, RoutedEventArgs e)
        {
            using (UserDataContext context = new UserDataContext())
            {
                string useride = (string)GetValue(Settings.UidProperty);
                int userid = int.Parse(useride);
                User? user = context.Users.Find(userid);
                bool emailfound = context.Users.Any(user => user.Email == (txtChangeEmail.Text).ToLower() && user.Id != userid);
                if (user != null)
                {
                    user.Name = txtChangeName.Text;
                    user.LastName = txtChangeLastName.Text;
                    user.City = txtChangeCity.Text;
                    user.Country = txtChangeCountry.Text;
                    
                    if(!emailfound) { 
                        user.Email = (txtChangeEmail.Text).ToLower();
                    }
                    user.HouseNr = txtChangeHouseNr.Text;
                    user.Province = txtChangeProvince.Text;
                    user.Street = txtChangeStreet.Text;

                    context.SaveChanges();


                    ShowUserInfo();
                }
                if (!emailfound)
                {
                    MessageBox.Show("Your account credentials were succesfully modified.");ShowUserInfo();
                    context.Logs.Add(new Log() { UserId = userid, Description = "Account settings / credentials were modified.", Action = "PencilBox", Timestamp = DateTime.Now.ToString("d-M-yyyy - HH:mm") });
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Your account credentials were modified except: email -> already in use.");
                    context.Logs.Add(new Log() { UserId = userid, Description = "Account credentials where modified exept: email already in use.", Action = "PencilBox", Timestamp = DateTime.Now.ToString("d-M-yyyy - HH:mm") });
                    context.SaveChanges();
                }
                    


            }
        }
    }
}
