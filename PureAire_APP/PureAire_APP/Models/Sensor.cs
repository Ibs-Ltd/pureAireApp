using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;

namespace PureAire_APP.Models
{
    public class Sensor
    {

        public Models.SensorData CollectData()
        {
            String str = @"Server=; Port=3306; Database=; Uid=; Pwd=";
            string userID = Models.DBFields.UserID;
            MySqlConnection con2 = new MySqlConnection(str);
            //String GetData = $"select * from iaq_data where user_id = 27 order by Log_id desc limit 1";
            String GetData = $"select * from iaq_data where user_id = {userID} order by Log_id desc limit 1";
            MySqlCommand myCmd = new MySqlCommand(GetData, con2);
            con2.Open();
            MySqlDataReader reader = myCmd.ExecuteReader();
            Models.SensorData sensorData = new Models.SensorData();

            try
            {             
                    reader.Read();                 
                    string nCO2 = sensorData.CO2 = reader.GetInt32("co2").ToString();
                    string nPM = sensorData.PM = reader.GetInt32("pm25").ToString();
                    double nVOC = sensorData.VOC = reader.GetDouble("tvoc");
                    string nTemp = sensorData.Temp = reader.GetInt32("temp").ToString();
                    string nHumid = sensorData.Humid = reader.GetInt32("humid").ToString();
                    //App.Current.MainPage.DisplayAlert("Success", "Your CO2 is: " + nCO2 + " PM: " + nPM, "OK");
                    reader.Close();
                    con2.Close();

                return new Models.SensorData()
                {
                    PM = nPM,
                    CO2 = nCO2,
                    VOC = nVOC,
                    Temp = nTemp+"°F",
                    Humid = nHumid+"%"
                };


            }
            catch (Exception err)
            {
                Console.WriteLine("NM ERROR IS: " + err + " NM ERROR END HERE");
                return new Models.SensorData()
                {
                    PM = null,
                    CO2 = null,
                    VOC = 0,
                    Temp = null,
                    Humid = null
                };
            }
        }


    }
}
