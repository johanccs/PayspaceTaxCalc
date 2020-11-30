using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PS.Data.DTO;
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
                    return null;
                }
            }

            return null;
        }
    }
}
