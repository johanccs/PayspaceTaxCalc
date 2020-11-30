using Microsoft.Extensions.Configuration;
using PS.Client.Web.Models;

namespace PS.Client.Web.LocalService
{
    public static class ApiHandler
    {
        public static string Handle(TaxCalculationModel tc, IConfiguration config)
        {
            var baseUrl = config["BaseApiUrl"];

            return null;
        }
    }
}
