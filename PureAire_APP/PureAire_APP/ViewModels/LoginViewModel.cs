using PureAire_APP.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using Xamarin.Essentials;
//using MySql.Data.MySqlClient;
using MySqlConnector;



namespace PureAire_APP.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        public ICommand PasswordCommand { get; }
        public ICommand NewAccountCommand { get; }
        MySqlConnection con = null;
        MySqlDataReader EmailReader = null;

        public LoginViewModel()
        {

            PasswordCommand = new Command(async () => await Browser.OpenAsync("https://migro.com"));
            NewAccountCommand = new Command(async () => await Browser.OpenAsync("https://migro.com"));       

        }

        public void AccountInfo(string email, string passwrd)
        {
            
            try
            {
                String str = @"Server=; Port=3306; Database=; Uid=; Pwd=";
                con = new MySqlConnection(str);                
                String VerifyEmail = "select * from user where email = '" + email + "'";
                MySqlCommand emlCmd = new MySqlCommand(VerifyEmail, con);
                con.Open();
                EmailReader = (MySqlDataReader)emlCmd.ExecuteReader();
                EmailReader.Read();
                int dbUserID = (int)EmailReader[0];
                Models.DBFields.UserID = dbUserID.ToString();
                String dbPasswrd = EmailReader[2].ToString();
                //con.Close();

                if (dbPasswrd == passwrd)
                {
                    //Models.Sensor data = new Models.Sensor();
                    //var CollectedData = data.CollectData();                 
                    //string CO2 = CollectedData.CO2;
                    //string PM = CollectedData.PM;
                    //App.Current.MainPage.DisplayAlert("Success", "Connection Succesful! YouruserID is: " + dbUserID, "OK");
                    //IAQMonitorViewModel initData = new IAQMonitorViewModel();
                    //initData.SetMonitorData();
                    Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                    //new NavigationPage(new HomePage());


                }

                else { App.Current.MainPage.DisplayAlert("ERROR", "Incorrect Password", "Try Again"); }

            }
            catch (Exception err)
            {
                Console.WriteLine("NM ERROR IS: "+err+" NM ERROR ENDS HERE");
                //string msgText = "Couldn't find your Migro Account";
                //App.Current.MainPage.DisplayAlert("ERROR", msgText, "Try Again");
            }
        }

    }

    //private async void OnLoginClicked(object obj)
    //{
    //    // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
    //    await Shell.Current.GoToAsync($"//{nameof(HomePage)}");


    //}
//}


}
