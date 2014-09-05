using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace framework.cspnetworks.net.Helpers
{
    public static class DropDonwHelper
    {

        public static IEnumerable<SelectListItem> GetItems(String dropDownApiMethod, String selectedValue)
        {

            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET                     
                response = client.GetAsync("api/DropDowns/" + dropDownApiMethod).Result;
            }

            Dictionary<String, String> dictionary = new Dictionary<String, String>();
            if (response.IsSuccessStatusCode)
            {
                dictionary = response.Content.ReadAsAsync<Dictionary<String, String>>().Result;
            }

            var names = dictionary.Keys.ToArray();
            var values = dictionary.Values.ToArray();

            var items = names.Zip(values, (name, value) =>
                    new SelectListItem
                    {
                        Text = name,
                        Value = value.ToString(),
                        Selected = value == selectedValue
                    }
                );
            return items;
        }
        
        //public static IEnumerable<SelectListItem> GetItems(this Type enumType, int? selectedValue)
        //{
        //    if (!typeof(Enum).IsAssignableFrom(enumType))
        //    {
        //        throw new ArgumentException("Type must be an enum");
        //    }

        //    var names = Enum.GetNames(enumType);
        //    var values = Enum.GetValues(enumType).Cast<int>();

        //    var items = names.Zip(values, (name, value) =>
        //            new SelectListItem
        //            {
        //                Text = GetName(enumType, name),
        //                Value = value.ToString(),
        //                Selected = value == selectedValue
        //            }
        //        );
        //    return items;
        //}

        //private static string GetName(Type enumType, string name)
        //{
        //    var result = name;

        //    var attrtibute = enumType
        //        .GetField(name)
        //        .GetCustomAttributes(inherit: false)
        //        .OfType<DisplayAttribute>()
        //        .FirstOrDefault();

        //    if (attrtibute != null)
        //    {
        //        result = attrtibute.GetName();
        //    }
        //    return result;
        //}


    }
}