using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JourneaseTechTest.AppCode
{
    public class BingMapsProvider : IMapProvider
    {
        private static readonly WebClient SynClient = new WebClient();

        private static string key;

        public BingMapsProvider()
        {
            key = " AsL49zUPu_pK3NUxNaca4SJIUmatanBn4MqHjv_FyACoSmjFuP9VhRDziTq8TrB8";
        }

        public bool postCodeExists(string postcode)
        {
            try
            {

                var json = SynClient.DownloadString(
                    $"http://dev.virtualearth.net/REST/v1/Locations?query={postcode}unitedkingdom&includneighborhood=0&maxResults=10&include=queryParse&key={key}");
                   // $"http://dev.virtualearth.net/REST/v1/Locations/GB/{postcode}?key={key}");

                JObject jsonData = JObject.Parse(json);
                foreach (var resource in jsonData["resourceSets"].Children().ToList())
                {
                    var testo = resource.Children().Last().First().First()["address"];
                    string formattedAdress =
                        testo["formattedAddress"].ToString().ToUpper().Replace(" ", "");

                    if (formattedAdress.Contains(postcode.ToUpper().Replace(" ","")))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Coordinates GetCoordinates(string postcode)
        {
            var json = SynClient.DownloadString(
                $"http://dev.virtualearth.net/REST/v1/Locations/GB/{postcode}?key={key}");

            JObject jsonData = JObject.Parse(json);
            IList<JToken> results = jsonData["resourceSets"].Children().First().Children().Last().First().First()["point"].Last().First().ToList();

            Coordinates locationToReturn = new Coordinates()
            {
                latitude = (decimal)results.First(),
                longitude = (decimal)results.Last()
            };

            return locationToReturn;
        }

    }
}
    