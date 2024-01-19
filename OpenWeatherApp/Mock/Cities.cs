using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace OpenWeatherApp.Mock
{
    public class Cities
    {
        public static IEnumerable<SelectListItem> GetCities(string country)
        {
            IList<SelectListItem> cities = new List<SelectListItem>();


            switch (country)
            {
                case "US":
                    cities = new List<SelectListItem>
                    {
                        new SelectListItem() {Text = "Chicago", Value = "Chicago"},
                        new SelectListItem() {Text = "Dallas", Value = "Dallas"},
                        new SelectListItem() {Text = "Denver", Value = "Denver"},
                    };
                    break;

                case "INA":
                    cities = new List<SelectListItem>
                    {
                        new SelectListItem() {Text = "Bandung", Value = "Bandung"},
                        new SelectListItem() {Text = "Jakarta", Value = "Jakarta"},
                        new SelectListItem() {Text = "Medan", Value = "Medan"},
                    };
                    break;

                case "BZ":
                    cities = new List<SelectListItem>
                    {
                        new SelectListItem() {Text = "Manaus", Value = "Manaus"},
                        new SelectListItem() {Text = "Recife", Value = "Recife"},
                        new SelectListItem() {Text = "Salvador", Value = "Salvador"},
                    };
                    break;

                case "UK":
                    cities = new List<SelectListItem>
                    {
                        new SelectListItem() {Text = "London", Value = "London"},
                    };
                    break;

                case "SA":
                    cities = new List<SelectListItem>
                    {
                        new SelectListItem() {Text = "Pretoria", Value = "Pretoria"},
                        new SelectListItem() {Text = "Soweto", Value = "Soweto"},

                    };
                    break;

                default:
                    cities = new List<SelectListItem>
                    {
                        new SelectListItem() {Text = "", Value = ""},
                        new SelectListItem() {Text = "Please Select City", Value = "Please Select City"},
                    };
                    break;
            }

            return cities;
        }
    }
}
