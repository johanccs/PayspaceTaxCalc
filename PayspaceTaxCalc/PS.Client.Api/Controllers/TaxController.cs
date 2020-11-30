using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PS.Contracts.Logging;
using PS.Contracts.Repositories;
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
        private readonly ITaxResultRepository _taxResultRepo;
        #endregion

        #region Constructor

        public TaxController(
            ILogManager logger, IMapper mapper, 
            ICalculateTaxService taxService, ITaxResultRepository taxResultRepo)
        {
            _logger = logger;
            _mapper = mapper;
            _taxService = taxService;
            _taxResultRepo = taxResultRepo;
        }

        #endregion

        #region Action Result

        [HttpGet]
        public IActionResult GetTaxPayable()
        {
            try
            {
                var result = _taxResultRepo.FindAll();

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
