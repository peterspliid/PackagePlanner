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

        public void SetApiRequestParamsToDefaultTelstar()
        {
            //Set default values
            cargoType = "dsaf";
            recorded = "true";
            packageLength = 1;
            packageWidth = 2;
            packageHeight = 3;
            packageWeight = 4;
            fromDestination = "marrakesh";
            toDestination = "tanger";
        }

        public void SetApiRequestParamsToDefaultEIT()
        {
            //Set default values
            cargoType = "std";
            recorded = "false";
            packageLength = 1;
            packageWidth = 2;
            packageHeight = 3;
            packageWeight = 4;
            fromDestination = "dakar";
            toDestination = "deKanariskeOer";
        }

        public void SetApiRequestParamsToDefault()
        {
            //Set default values
            cargoType = "dsaf";
            recorded = "false";
            packageLength = 1;
            packageWidth = 2;
            packageHeight = 60;
            packageWeight = 6;
            fromDestination = "marrakesh";
            toDestination = "amatave";
        }


        public Dictionary<string, string> UpdateAndFormatDictionary()
        {
            if (paramsDictionary.ContainsKey("cargoType"))
            {
                return paramsDictionary;
            }
            //typecast doubles to int to support external apis
            packageLength = (int) packageLength;
            packageHeight = (int)packageHeight;
            packageWidth = (int)packageWidth;
            packageWeight = (int)packageWeight;

            paramsDictionary.Add("cargoType",cargoType);
            paramsDictionary.Add("recorded", recorded);
            paramsDictionary.Add("packageLength", packageLength.ToString());
            paramsDictionary.Add("packageHeight", packageHeight.ToString());
            paramsDictionary.Add("packageWidth", packageWidth.ToString());
            paramsDictionary.Add("packageWeight", packageWeight.ToString());
            paramsDictionary.Add("fromDestination", fromDestination);
            paramsDictionary.Add("toDestination", toDestination);

            return paramsDictionary;
        }
    }

    
}