using System.ComponentModel.DataAnnotations;

namespace KVPFlights.Models
{
    public class AirlineInfo
    {
        [Key]
        public int AirlineID { get; set; }
        public string? AirlineName { get; set; }
        public string? ContactNumber { get; set; }
        public string? ContactAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public Boolean ? IsActive { get; set; }

    }
}
