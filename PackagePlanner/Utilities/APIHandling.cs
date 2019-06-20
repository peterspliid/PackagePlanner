using System;
using System.Collections.Generic;
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

        public static int GetPriceFromOceanicAirlinesAPI()
        {
            var url = "http://wa-oadk.azurewebsites.net/api";
            DeliveryApi delivery = APIHandling.AsyncTaskCallWebApiAsync(url);

            return delivery.price;
        }

        public static int GetPriceFromTelstarAPI()
        {
            var url = "http://wa-tldk.azurewebsites.net/api/GetTelstarRouteExternal?";

            DeliveryApi delivery = APIHandling.AsyncTaskCallWebApiAsync(url);

            return delivery.price;
        }

        public static int GetPriceFromEITcompanyAPI()
        {
            var url = "http://wa-oadk.azurewebsites.net/api";
            DeliveryApi delivery = APIHandling.AsyncTaskCallWebApiAsync(url);

            return delivery.price;
        }

        public static DeliveryApi AsyncTaskCallWebApiAsync(string url)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));  
                //GET Method  
                HttpResponseMessage response = client.GetAsync(("api")).Result;  
                if (response.IsSuccessStatusCode)  
                {
                    DeliveryApi delivery = response.Content.ReadAsAsync<DeliveryApi>().Result;  
                    Console.WriteLine("Id:{0}\tName:{1}", delivery.price, delivery.time);
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