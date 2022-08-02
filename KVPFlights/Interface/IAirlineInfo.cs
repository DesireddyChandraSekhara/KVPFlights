using KVPFlights.Models;

namespace KVPFlights.Interface
{
    public interface IAirlineInfo
    {
        public List<AirlineInfo> GetAirlineDetails();
        public AirlineInfo GetAirlineDetails(int id);
        public void AddAirline(AirlineInfo airlineInfo);
        public void UpdateAirline(AirlineInfo airlineInfo);
        public AirlineInfo DeleteAirline(int id);
        public bool CheckAirline(int id);
    }
}
