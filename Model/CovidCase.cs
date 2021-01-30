using System;

namespace CovidData.Model
{
    /// <summary>
    /// Klasa CovidCase se koristi kao klasa za podatke koji se dobivaju 
    /// preko https://api.covid19api.com/dayone/country/croatia
    /// "ID": "367fe340-c374-4baa-992e-426797870dd7",
    /// "Country": "Croatia",
    /// "CountryCode": "HR",
    /// "Province": "",
    /// "City": "",
    /// "CityCode": "",
    /// "Lat": "45.1",
    /// "Lon": "15.2",
    /// "Confirmed": 1,
    /// "Deaths": 0,
    /// "Recovered": 0,
    /// "Active": 1,
    /// "Date": "2020-02-25T00:00:00Z"
    /// </summary>
    public class CovidCase
    {
        public string ID { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string CityCode { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
        public int Active { get; set; }
        public DateTime Date { get; set; }
    }
}
