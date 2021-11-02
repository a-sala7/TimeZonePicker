using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeZonePicker
{
    public class TzAndCountryInfo
    {
        public IEnumerable<CountryItem> Countries { get; set; }
        public IEnumerable<TimeZoneItem> TimeZones { get; set; }
    }
}
