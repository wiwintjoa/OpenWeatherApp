using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace OpenWeatherApp.Mock
{
    public class Countries
    {
        public static IEnumerable<SelectListItem> GetCountries()
        {
            IList<SelectListItem> countries = new List<SelectListItem>();

            countries.Add(new SelectListItem() { Text = "United States", Value = "US" });
            countries.Add(new SelectListItem() { Text = "Indonesia", Value = "INA" });
            countries.Add(new SelectListItem() { Text = "Brazil", Value = "BZ" });
            countries.Add(new SelectListItem() { Text = "United Kingdom", Value = "UK" });
            countries.Add(new SelectListItem() { Text = "South Africa", Value = "SA" });

            return countries;
        }
    }
}
