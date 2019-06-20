using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using PackagePlanner.ERPCustomer;
        using System.Xml;
using System.Net;
using System.IO;

namespace PackagePlanner.Utilities
{
    public class ErpIntegration
    {
        // Web reference http://navvm2-oadk-03.westeurope.cloudapp.azure.com:7047/DynamicsNAV110/WS/Oceanic%20Airlines/Page/Customers
        public ErpIntegration()
        {

        }

 
public static void CallWebService()
    {
        var _url = "http://navvm2-oadk-03.westeurope.cloudapp.azure.com:7047/DynamicsNAV110/WS/Oceanic%20Airlines/Page/Customers";
        var _action = "http://navvm2-oadk-03.westeurope.cloudapp.azure.com:7047/DynamicsNAV110/WS/Oceanic%20Airlines/Page/Customers?op=Read";

        XmlDocument soapEnvelopeXml = CreateSoapEnvelope();
        HttpWebRequest webRequest = CreateWebRequest(_url,_action);
        InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            // Add credentials
            webRequest.Credentials = new NetworkCredential("navvm-admin", "m38cHjfet9sjWc11h");
        
        // begin async call to web request.
        IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

        // suspend this thread until call is complete. You might want to
        // do something usefull here like update your UI.
        asyncResult.AsyncWaitHandle.WaitOne();

        // get the response from the completed web request.
        string soapResult;
        using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
        {
            using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
            {
                soapResult = rd.ReadToEnd();
            }
            Console.Write(soapResult);
        }
    }

    private static HttpWebRequest CreateWebRequest(string url, string action)
    {
        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
        webRequest.Headers.Add("SOAPAction", action);
        webRequest.ContentType = "text/xml;charset=\"utf-8\"";
        webRequest.Accept = "text/xml";
        webRequest.Method = "POST";
        return webRequest;
    }

    private static XmlDocument CreateSoapEnvelope()
    {
        XmlDocument soapEnvelopeDocument = new XmlDocument();
        soapEnvelopeDocument.LoadXml(@"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/1999/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/1999/XMLSchema""><SOAP-ENV:Body><HelloWorld xmlns=""http://tempuri.org/"" SOAP-ENV:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""><int1 xsi:type=""xsd:integer"">12</int1><int2 xsi:type=""xsd:integer"">32</int2></HelloWorld></SOAP-ENV:Body></SOAP-ENV:Envelope>");
        return soapEnvelopeDocument;
    }

    private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
    {
        using (Stream stream = webRequest.GetRequestStream())
        {
            soapEnvelopeXml.Save(stream);
        }
    }

}

}