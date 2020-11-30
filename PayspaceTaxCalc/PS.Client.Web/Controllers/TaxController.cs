using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PS.Client.Web.LocalService;
using PS.Client.Web.Models;
using PS.Contracts.Services;

namespace PS.Client.Web.Controllers
{
    public class TaxController : Controller
    {
        #region Readonly Fields

        private readonly IConfiguration _config;
      
        #endregion

        #region Constructor

        public TaxController(IConfiguration config)
        {
            _config = config;
        }

        #endregion

        public IActionResult Index()
        {
            var taxCalc = new TaxCalculationModel();

            return View(taxCalc);
        }

        public IActionResult Create()
        {
            var taxCalc = new TaxCalculationModel();

            return View(taxCalc);
        }

        public IActionResult Success()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaxCalculationModel tc)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(500, "Internal Server Error");
            }

            var result = ApiHandler.Handle(tc, _config);

            ViewData["Result"] = result;

            return RedirectToAction("Success");
        }
    }
}
