using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KVPFlights.Models
{
    public class UserInfo
    {

        [JsonIgnore]
       
        public int UserId { get; set; }
        [JsonIgnore]
        public string? DisplayName { get; set; }
        [JsonIgnore]
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
    }
}
