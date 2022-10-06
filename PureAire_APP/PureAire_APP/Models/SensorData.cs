using System;
using System.Collections.Generic;
using System.Text;

namespace PureAire_APP.Models
{
    public class SensorData
    {
        public string PM { get; set; }
        public string Temp { get; set; }
        public string Humid { get; set; }
        public string CO2 { get; set; }
        public double VOC { get; set; }
    }
}
