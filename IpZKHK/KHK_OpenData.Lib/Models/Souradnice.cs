using KHK_OpenData.Lib.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace KHK_OpenData.Lib.Models
{
    public class Souradnice : IFromStringConvertable
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Souradnice()
        {

        }

        public Souradnice(string point)
        {
            double longitude;
            double latitude;

            int startOfLongitude = point.IndexOf("(") + 1;
            int startOfLatitude = point.IndexOf(" ", startOfLongitude) + 1;

            int lenghtOfLongitude = startOfLatitude - startOfLongitude - 1;
            int lenghtOfLatitude = point.Length - startOfLatitude - 1;

            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;

            if (double.TryParse(point.Substring(startOfLongitude, lenghtOfLongitude), NumberStyles.AllowDecimalPoint, nfi, out longitude))
            {
                Longitude = longitude;
                if (double.TryParse(point.Substring(startOfLatitude, lenghtOfLatitude), NumberStyles.AllowDecimalPoint, nfi, out latitude))
                {
                    Latitude = latitude;
                }
            }
        }

        public Souradnice(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double VzdalenostDo(Souradnice souradnice)
        {
            return VzdalenostMezi(this, souradnice);
        }
        public static double VzdalenostMezi(Souradnice a, Souradnice b)
        {
            int R = 6378137;
            double pi180 = Math.PI / 180;
            double φ1 = pi180 * a.Latitude;
            double φ2 = pi180 * b.Latitude;
            double Δφ = pi180 * (b.Latitude - a.Latitude);
            double Δλ = pi180 * (b.Longitude - a.Longitude);

            double A = Math.Sin(Δφ / 2) * Math.Sin(Δφ / 2) +
                    Math.Cos(φ1) * Math.Cos(φ2) *
                    Math.Sin(Δλ / 2) * Math.Sin(Δλ / 2);
            double C = 2 * Math.Atan2(Math.Sqrt(A), Math.Sqrt(1 - A));
            return R * C;
        }
        public override string ToString()
        {
            return "POINT (" + Longitude.ToString() + " " + Latitude.ToString() + ")";
        }

        public object CreateFromString(string input)
        {
            return new Souradnice(input);
        }

        public static Souradnice SouradniceZAdresy(string obec, string ulice, string cisloPopisne)
        {
            HttpDataProvider dataProvider = new HttpDataProvider(new Uri(@"https://nominatim.openstreetmap.org/search/cz/" + obec + "/" + ulice + "/" + cisloPopisne + "?format=json"));
            var data = new StreamReader(dataProvider.GetStream().Result).ReadToEnd();
            double lat = 0, lon = 0;
            if (data != null)
            {
                JArray deserializedObject = JsonConvert.DeserializeObject(data) as JArray;

                foreach (JToken obj in deserializedObject)
                {
                    foreach (JProperty property in obj)
                    {
                        if (property.Name == "lat")
                            lat = Convert.ToDouble(property.Value);
                        else if (property.Name == "lon")
                            lon = Convert.ToDouble(property.Value);
                    }
                }
                return new Souradnice(lat, lon);
            }
            return null;
        }

        public static string[] ObecZeSouradnic(Souradnice souradnice)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            HttpDataProvider dataProvider = new HttpDataProvider(new Uri(@"https://nominatim.openstreetmap.org/reverse?format=jsonv2&lat=" + souradnice.Latitude.ToString(nfi) + "&lon=" + souradnice.Longitude.ToString(nfi)));
            var data = new StreamReader(dataProvider.GetStream().Result).ReadToEnd();
            string[] obec = new string[2];
            if (data != null)
            {
                JToken deserializedObject = JsonConvert.DeserializeObject(data) as JToken;

                foreach (JProperty property in deserializedObject)
                {
                    if (property.Name == "address")
                    {
                        foreach (JProperty property2 in property.Value)
                        {
                            if (property2.Name == "city")
                                obec[1] = property2.Value.ToString();
                            else if (property2.Name == "village")
                                obec[1] = property2.Value.ToString();
                        }
                    }
                    else if (property.Name == "name")
                        obec[0] = property.Value.ToString();
                    
                }
                return obec;
            }
            return null;
        }
    }
}
