using KVPFlights.Interface;
using KVPFlights.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KVPFlights.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        private readonly IAirlineInfo _IAirlineInfo;

        public AirlineController(IAirlineInfo iAirlineInfo)
        {
            _IAirlineInfo = iAirlineInfo;
        }

        // GET: api/Airline>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirlineInfo>>> Get()
        {
            return await Task.FromResult(_IAirlineInfo.GetAirlineDetails());
        }

        // GET api/Airline/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirlineInfo>> Get(int id)
        {
            var employees = await Task.FromResult(_IAirlineInfo.GetAirlineDetails(id));
            if (employees == null)
            {
                return NotFound();
            }
            return employees;
        }

        // POST api/Airline
        [HttpPost]
        public async Task<ActionResult<AirlineInfo>> Post(AirlineInfo airlineInfo)
        {
            _IAirlineInfo.AddAirline(airlineInfo);
            return await Task.FromResult(airlineInfo);
        }

        // PUT api/Airline/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AirlineInfo>> Put(int id, AirlineInfo airlineInfo)
        {
            if (id != airlineInfo.AirlineID)
            {
                return BadRequest();
            }
            try
            {
                _IAirlineInfo.UpdateAirline(airlineInfo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirlineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(airlineInfo);
        }

        // DELETE api/Airline/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AirlineInfo>> Delete(int id)
        {
            var airlineInfo = _IAirlineInfo.DeleteAirline(id);
            return await Task.FromResult(airlineInfo);
        }

        private bool AirlineExists(int id)
        {
            return _IAirlineInfo.CheckAirline(id);
        }
    }
}
