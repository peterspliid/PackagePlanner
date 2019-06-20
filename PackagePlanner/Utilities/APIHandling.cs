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


        static async Task<DeliveryApi> GetProductAsync(string path)
        {
            DeliveryApi delivery = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                delivery = await response.Content.ReadAsAsync<DeliveryApi>();
            }
            return delivery;
        }

    }

}