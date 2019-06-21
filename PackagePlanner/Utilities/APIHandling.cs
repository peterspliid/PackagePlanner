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

namespace PackagePlanner.Utilities
{
    public static class APIHandling
    {
        private static HttpClient client = new HttpClient();

        public static DeliveryData GetApiDeliveryDataFromOceanicAirlinesAPI(Dictionary<String, String> parameters)
        {
            var url = "http://wa-oadk.azurewebsites.net/api/delivery?";
            DeliveryData delivery = APIHandling.AsyncTaskCallWebApiAsync(url, parameters);

            return delivery;
        }

        public static DeliveryData GetApiDeliveryDataFromTelstarAPI(Dictionary<String, String> parameters)
        {
            var url = "http://wa-tldk.azurewebsites.net/api/GetTelstarRouteExternal?";

            DeliveryData delivery = APIHandling.AsyncTaskCallWebApiAsync(url, parameters);

            return delivery;
        }

        public static DeliveryData GetApiDeliveryDataFromEITcompanyAPI(Dictionary<String, String> parameters)
        {
            var url = "http://wa-eitdk.azurewebsites.net/api/GetEITRoute?";
            DeliveryData delivery = APIHandling.AsyncTaskCallWebApiAsync(url, parameters);

            return delivery;
        }

        public static DeliveryData AsyncTaskCallWebApiAsync(string url, Dictionary<String, String> parameters)
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
            HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        DeliveryData delivery = response.Content.ReadAsAsync<DeliveryData>().Result;
                        Debug.WriteLine("Id:{0}\tName:{1}", delivery.price, delivery.time);
                        Debug.WriteLine("URL: {0}", client.BaseAddress);
                        return delivery;
                    }
                    catch (Exception e)
                    {
                    }

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }

                return new DeliveryData();
        }
    }
}