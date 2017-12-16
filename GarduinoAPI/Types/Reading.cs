using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarduinoAPI.Types
{
    public class Reading
    {
        public int Id { get; set; }
        public int GardenId { get; set; }
        public DateTime Date { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Moisture { get; set; }
        public double Light { get; set; }
    }
}
