using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ServiceStack.DataAnnotations;

namespace GarduinoAPI.Models
{
    public class Reading
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Garden), OnDelete = "CASCADE", OnUpdate = "CASCADE")]
        public int GardenId { get; set; }

        public DateTime? Date { get; set; } = DateTime.Now;

        public double Temperature { get; set; }

        public double Humidity { get; set; }

        public double Moisture { get; set; }
        
        public double Light { get; set; }
    }
}
