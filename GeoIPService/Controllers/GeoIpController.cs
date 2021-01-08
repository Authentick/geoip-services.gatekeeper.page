using System.Net;
using MaxMind.GeoIP2;
using MaxMind.GeoIP2.Exceptions;
using MaxMind.GeoIP2.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GeoIPService.Controllers
{
    [ApiController]
    [Route("")]
    public class GeoIpController : ControllerBase
    {
        private readonly DatabaseReaderProvider _databaseReaderProvider;

        public GeoIpController(DatabaseReaderProvider databaseReaderProvider)
        {
            _databaseReaderProvider = databaseReaderProvider;
        }

        [HttpGet("{ipAddress}")]
        public GeoIpData Get(string ipAddress)
        {
            IPAddress ip;
            try
            {
                ip = IPAddress.Parse(ipAddress);
            }
            catch
            {
                return new GeoIpData { Success = false };
            }

            DatabaseReader reader = _databaseReaderProvider.GetReader();

            CityResponse cityResponse;
            try
            {
                cityResponse = reader.City(ip);
            }
            catch (AddressNotFoundException)
            {
                return new GeoIpData { Success = false };
            }

            return new GeoIpData
            {
                Success = true,
                City = cityResponse.City.Name,
                CountryCode = cityResponse.Country.IsoCode,
            };
        }
    }
}
