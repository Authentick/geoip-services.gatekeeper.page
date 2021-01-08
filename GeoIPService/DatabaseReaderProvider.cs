using MaxMind.GeoIP2;
using Microsoft.Extensions.Configuration;

namespace GeoIPService {
    public class DatabaseReaderProvider {
        private readonly IConfiguration _config;


        public DatabaseReaderProvider(IConfiguration config)
        {
            _config = config;
        }


        public DatabaseReader GetReader() 
        {
            string fileLocation = _config.GetValue<string>("GeoLiteFile");
            return new DatabaseReader(fileLocation);
        }
    }
}
