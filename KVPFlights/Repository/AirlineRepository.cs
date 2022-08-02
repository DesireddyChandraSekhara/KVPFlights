using KVPFlights.Interface;
using KVPFlights.Models;
using Microsoft.EntityFrameworkCore;

namespace KVPFlights.Repository
{
    public class AirlineRepository : IAirlineInfo
    {
        readonly DatabaseContext _dbContext = new();

        public AirlineRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddAirline(AirlineInfo airlineInfo)
        {
            try
            {
                _dbContext.AirlineInfo.Add(airlineInfo);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public bool CheckAirline(int id)
        {
            return _dbContext.AirlineInfo.Any(e => e.AirlineID == id);
        }

        public AirlineInfo DeleteAirline(int id)
        {
            try
            {
                AirlineInfo? airlineInfo = _dbContext.AirlineInfo.Find(id);

                if (airlineInfo != null)
                {
                    _dbContext.AirlineInfo.Remove(airlineInfo);
                    _dbContext.SaveChanges();
                    return airlineInfo;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public List<AirlineInfo> GetAirlineDetails()
        {
            try
            {
                return _dbContext.AirlineInfo.ToList();
            }
            catch
            {
                throw;
            }
        }

        public AirlineInfo GetAirlineDetails(int id)
        {
            try
            {
                AirlineInfo? airlineInfo = _dbContext.AirlineInfo.Find(id);
                if (airlineInfo != null)
                {
                    return airlineInfo;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void UpdateAirline(AirlineInfo airlineInfo)
        {
            try
            {
                _dbContext.Entry(airlineInfo).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
