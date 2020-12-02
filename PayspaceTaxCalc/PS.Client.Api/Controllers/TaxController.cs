using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PS.Contracts.Logging;
using PS.Contracts.Repositories;
using PS.Contracts.Services;
using PS.Data;
using PS.Data.DTO;
using System;
using System.Linq;

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
        private readonly IRepositoryWrapper _repoWrapper;
        #endregion

        #region Constructor

        public TaxController(
            ILogManager logger, IMapper mapper, 
            ICalculateTaxService taxService, IRepositoryWrapper repoWrapper)
        {
            _logger = logger;
            _mapper = mapper;
            _taxService = taxService;
            _repoWrapper = repoWrapper;
        }

        #endregion

        #region Action Result

        [HttpGet]
        public IActionResult GetTaxPayable()
        {
            try
            {
                var result = _repoWrapper.TaxResultRepository.FindAll().ToList();

                return Ok(result);
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

                var internalTaxResult = new TaxResult
                {
                    Date = DateTime.Now,
                    AnnualIncome = taxCalc.AnnualIncome,
                    PostalCode = taxCalc.PostalCode,
                    Result = taxResult
                };

                _repoWrapper.TaxResultRepository.Create(internalTaxResult);
                _repoWrapper.Save();

                return Ok(taxResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return StatusCode(500, "Internal Service Error");
            }
        }

        #endregion

    }
}
