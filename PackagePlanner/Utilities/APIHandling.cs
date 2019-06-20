using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using PackagePlanner.Models;

namespace PackagePlanner.Utilities
{
    public static class APIHandling
    {
        static HttpClient client = new HttpClient();


        static async Task<DeliveryData> GetProductAsync(string path)
        {
            DeliveryData deliveryData = new DeliveryData();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                deliveryData = await response.Content.ReadAsAsync<DeliveryData>();
            }
            return deliveryData;
        }

    }

}