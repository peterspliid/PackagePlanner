using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackagePlanner.Models
{
    public class ApiRequestParams
    {
        public string cargoType { get; set; }
        public string recorded { get; set; }
        public double packageLength { get; set; }
        public double packageWidth { get; set; }
        public double packageHeight { get; set; }
        public double packageWeight { get; set; }
        public string fromDestination { get; set; }
        public string toDestination { get; set; }

        private Dictionary<string, string> paramsDictionary { get; }

        public ApiRequestParams()
        {
            paramsDictionary = new Dictionary<string, string>();
        }
        public void SetApiRequestParamsToDefault()
        {
            //Set default values
            cargoType = "refr";
            recorded = "false";
            packageLength = 50;
            packageHeight = 50;
            packageWidth = 50;
            packageWeight = 6;
            fromDestination = "stHelena";
            toDestination = "hvalbugten";
        }

        public Dictionary<string, string> UpdateAndFormatDictionary()
        {
            paramsDictionary.Add("cargoType",cargoType);
            paramsDictionary.Add("recorded", recorded);
            paramsDictionary.Add("packageLength", packageLength.ToString("0.00"));
            paramsDictionary.Add("packageHeight", packageHeight.ToString("0.00"));
            paramsDictionary.Add("packageWidth", packageWidth.ToString("0.00"));
            paramsDictionary.Add("packageWeight", packageWeight.ToString("0.00"));
            paramsDictionary.Add("fromDestination", fromDestination);
            paramsDictionary.Add("toDestination", toDestination);

            return paramsDictionary;
        }
    }

    
}