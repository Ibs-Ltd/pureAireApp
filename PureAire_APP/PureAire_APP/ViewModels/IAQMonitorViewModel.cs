using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data;
using System.Timers;

namespace PureAire_APP.ViewModels
{
    public class IAQMonitorViewModel : BaseViewModel, INotifyPropertyChanged
    {

        public Command ConnectDB { get; }
        public string _pm25 = string.Empty;
        public string _co2 = string.Empty;
        public string _voc = string.Empty;
        public string _temp = string.Empty;
        public string _humid = string.Empty;

        public event PropertyChangedEventHandler PropertyChanged;
        public string PM25 { get => _pm25; set { _pm25 = value; OnPropertyChanged(); } }
        public string CO2 { get => _co2; set { _co2 = value; OnPropertyChanged(); } }
        public string VOC { get => _voc; set { _voc = value; OnPropertyChanged(); } }
        public string TEMP { get => _temp; set { _temp = value; OnPropertyChanged(); } }
        public string HUMID { get => _humid; set { _humid = value; OnPropertyChanged(); } }

        protected void OnPropertyChanged([CallerMemberName]string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }   

        public IAQMonitorViewModel()
        {
            Title = "IAQ Monitoring";
            ConnectDB = new Command(SetTimer);

        }
        

        public void SetTimer()
        {
            SetMonitorData();
            Timer timerG = new Timer(1000 * 24) { AutoReset = true };
            timerG.Elapsed += DataTimer_Elapsed;
            timerG.Start();
        }

        private void DataTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (Models.DBFields.UserID != null)
                {
                    //ViewModels.IAQMonitorViewModel setData = new IAQMonitorViewModel();
                    SetMonitorData();
                }
            }); 
        }
        
        public void SetMonitorData()
        {
            Models.Sensor data = new Models.Sensor();
            var CollectedData = data.CollectData();
            string nCO2 = CollectedData.CO2;
            string nPM = CollectedData.PM;
            string nVOC = CollectedData.VOC.ToString();
            string nTemp = CollectedData.Temp;
            string nHumid = CollectedData.Humid;

            PM25 = nPM;
            CO2 = nCO2;
            VOC = nVOC;
            TEMP = nTemp;
            HUMID = nHumid;
        }

    }
}