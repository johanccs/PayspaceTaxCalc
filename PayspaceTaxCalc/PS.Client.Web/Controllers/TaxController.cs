using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PS.Client.Web.LocalService;
using PS.Client.Web.Models;
using PS.Contracts.Logging;
using PS.Contracts.Services;
using PS.Data.DTO;
using System;

namespace PS.Client.Web.Controllers
{
    public class TaxController : Controller
    {
        #region Readonly Fields

        private readonly IConfiguration _config;
        private readonly ILogManager _logger;
        private readonly IMapper _mapper;
      
        #endregion

        #region Constructor

        public TaxController(
            IConfiguration config, ILogManager logger, IMapper mapper)
        {
            _config = config;
            _logger = logger;
            _mapper = mapper;
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
        public IActionResult Create(TaxCalculationModel taxCalculation)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(500, "Internal Server Error");
                }

                var result = ApiHandler.Handle(
                    _mapper.Map<TaxCalcDto>(taxCalculation), _config);

                ViewData["Result"] = result;

                return RedirectToAction("Success");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred. See exception for more information - {ex.Message}");
                throw;
            }
        }
    }
}
