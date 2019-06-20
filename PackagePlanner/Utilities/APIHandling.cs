using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using PackagePlanner.Models;
using Newtonsoft.Json;

namespace PackagePlanner.Utilities
{
    public static class APIHandling
    {

        public static int GetPriceFromOceanicAirlinesAPI(Dictionary<String, String> parameters)
        {
            var url = "http://wa-oadk.azurewebsites.net/api?";
            DeliveryApi delivery = APIHandling.AsyncTaskCallWebApiAsync(url, parameters);

            return delivery.price;
        }

        public static int GetPriceFromTelstarAPI(Dictionary<String, String> parameters)
        {
            var url = "http://wa-tldk.azurewebsites.net/api/GetTelstarRouteExternal?";

            DeliveryApi delivery = APIHandling.AsyncTaskCallWebApiAsync(url, parameters);

            return delivery.price;
        }

        public static int GetPriceFromEITcompanyAPI(Dictionary<String, String> parameters)
        {
            var url = "http://wa-oadk.azurewebsites.net/api?";
            DeliveryApi delivery = APIHandling.AsyncTaskCallWebApiAsync(url, parameters);

            return delivery.price;
        }

        public static DeliveryApi AsyncTaskCallWebApiAsync(string url, Dictionary<String, String> parameters)
        {
            HttpClient client = new HttpClient();

            string query;
            using (var content = new FormUrlEncodedContent(parameters))
            {
                query = content.ReadAsStringAsync().Result;
            }

            url += query;
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // TODO: Add query to URL

            //GET Method  
            HttpResponseMessage response = client.GetAsync(query).Result;  

                if (response.IsSuccessStatusCode)  
                {
                    DeliveryApi delivery = response.Content.ReadAsAsync<DeliveryApi>().Result;  
                    Debug.WriteLine("Id:{0}\tName:{1}", delivery.price, delivery.time);
                    Debug.WriteLine("URL: {0}", client.BaseAddress);
                return delivery;
                }  
                else
                {
                    Console.WriteLine("Internal server Error");
                }
                return null;

        } 
          


    }

}