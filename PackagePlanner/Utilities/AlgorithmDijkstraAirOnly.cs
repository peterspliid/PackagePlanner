﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using PackagePlanner.Models;

namespace PackagePlanner.Utilities
{
    public static class AlgorithmDijkstraAirOnly
    {
        public static DeliveryData GetDeliveryData()
        {
            //ALL this can be replaced with new algorithm class

            ApiRequestParams parameters = new ApiRequestParams();
            parameters.SetApiRequestParamsToDefaultEIT();

            parameters.cargoType = "rsaf";

            DeliveryData delivery = APIHandling.GetApiDeliveryDataFromEITcompanyAPI(parameters.UpdateAndFormatDictionary());

            Console.Write("totalprice: " + delivery.price);

            return delivery;
        }
    }
}