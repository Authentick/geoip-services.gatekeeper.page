namespace GeoIPService
{
    public class GeoIpData
    {
        public bool Success { get; set; }
        public string? City { get; set; }
        public string? CountryCode { get; set; }
        public string LicenseInformation { get; set; } = "This product includes GeoLite2 data created by MaxMind, available from https://www.maxmind.com.";
    }
}
