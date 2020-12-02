using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PS.Data.DTO;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PS.Client.Web.LocalService
{
    public static class ApiHandler
    {
        public static async Task<string> Handle(
            TaxCalcDto taxCalculation, IConfiguration config)
        {
            var baseUrl = config["BaseApiUrl"];
            HttpResponseMessage response = null;


            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(
                            "application/json"));

                var serialisedObject = JsonConvert.SerializeObject(taxCalculation);
                var param = new StringContent(serialisedObject, Encoding.UTF8, "application/json");

                response = await client.PostAsync("api/Tax", param);

                if(response.IsSuccessStatusCode)
                {
                    var returnValue = response.Content.ReadAsStringAsync().Result;

                    return returnValue;
                }
            }

            return null;
        }

        public static string Handle(bool @overwrite, TaxCalcDto taxCalculation, IConfiguration config)
        {
            var baseUrl = config["BaseApiUrl"];
            var serverResponse = "";

            WebRequest request = WebRequest.Create(baseUrl + "api/Tax");
            request.Method = "POST";

            var serialisedObject = JsonConvert.SerializeObject(taxCalculation);
            byte[] byteArray = Encoding.UTF8.GetBytes(serialisedObject);

            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();

            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();

            using(dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                serverResponse = reader.ReadToEnd();
            }

            response.Close();

            return serverResponse;
        }
    }
}
