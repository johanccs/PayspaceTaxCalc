using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PS.Client.ServicesApi.QueryParameters;
using PS.Contracts.Logging;
using PS.Contracts.Services;
using PS.Data.DTO;
using System;

namespace PS.Client.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        #region Readonly Fields

        private readonly ILogManager _logger;
        private readonly IMapper _mapper;
        private readonly ICalculateTaxService _taxService;

        #endregion

        #region Constructor

        public TaxController(ILogManager logger, IMapper mapper, ICalculateTaxService taxService)
        {
            _logger = logger;
            _mapper = mapper;
            _taxService = taxService;
        }

        #endregion

        #region Action Result

        [HttpGet("{annualIncome}/{postalCode}")]
        public IActionResult GetTaxPayable(decimal annualIncome, string postalCode)
        {
            try
            {
                var taxCalcParam = new TaxCalcParam.Get(annualIncome, postalCode);

                var taxResult = _taxService.Calculate(_mapper.Map<TaxCalcDto>(taxCalcParam));

                return Ok(taxResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An unexpected error occurred: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult GetTaxPayable(TaxCalcDto taxCalc)
        {
            try
            {
                var taxResult = _taxService.Calculate(taxCalc);
                return Ok(taxResult);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

    }
}
