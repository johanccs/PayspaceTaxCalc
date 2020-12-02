using NUnit.Framework;
using PS.Application.Services.CalculationProcedure;
using PS.Data.DTO;
using PS.Repository;
using System;

namespace PS.Test
{
    [TestFixture]
    public class Tests
    {
        private CalculationManager _calcManager;       

        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void TestProgressivTaxTypeFORTenPercentRate_Pass()
        {
            TaxCalcDto taxCalc = new TaxCalcDto { AnnualIncome = 5000, PostalCode = "7441" };
            _calcManager = new CalculationManager(new MockRepositoryWrapper());

            decimal actual = _calcManager.Calculate(taxCalc);
            decimal expected = 500;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestProgressivTaxTypeFORTenPercentRate_Fail()
        {
            TaxCalcDto taxCalc = new TaxCalcDto { AnnualIncome = 5000, PostalCode = "7441" };
            _calcManager = new CalculationManager(new MockRepositoryWrapper());

            decimal actual = _calcManager.Calculate(taxCalc);
            decimal expected = 750;

            Assert.AreNotEqual(expected, actual);
        }

        [Test]
        public void TestProgressivTaxTypeFORFifteenPercentRate_Pass()
        {
            TaxCalcDto taxCalc = new TaxCalcDto { AnnualIncome = 8400, PostalCode = "7441" };
            _calcManager = new CalculationManager(new MockRepositoryWrapper());

            decimal actual = _calcManager.Calculate(taxCalc);
            decimal expected = 1260;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestProgressivTaxTypeFORFifteenPercentRate_Fail()
        {
            TaxCalcDto taxCalc = new TaxCalcDto { AnnualIncome = 8400, PostalCode = "7441" };
            _calcManager = new CalculationManager(new MockRepositoryWrapper());

            decimal actual = _calcManager.Calculate(taxCalc);
            decimal expected = 1261;

            Assert.AreNotEqual(expected, actual);
        }

        [Test]
        public void TestProgressivTaxTypeFORTwentyFivePercentRateWithExactAmount_Pass()
        {
            TaxCalcDto taxCalc = new TaxCalcDto { AnnualIncome = 33951, PostalCode = "7441" };
            _calcManager = new CalculationManager(new MockRepositoryWrapper());

            decimal actual = _calcManager.Calculate(taxCalc);
            decimal expected = 8487.75m;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestProgressivTaxTypeFORTwentyFivePercentRateWithExactAmount_Fail()
        {
            TaxCalcDto taxCalc = new TaxCalcDto { AnnualIncome = 33951, PostalCode = "7441" };
            _calcManager = new CalculationManager(new MockRepositoryWrapper());

            decimal actual = _calcManager.Calculate(taxCalc);
            decimal expected = 8487.76m;

            Assert.AreNotEqual(expected, actual);
        }

        [Test]
        public void TestProgressivTaxTypeFORTwentyFivePercentRateWithNegativeAmount_Fail()
        {
            TaxCalcDto taxCalc = new TaxCalcDto { AnnualIncome = -33952, PostalCode = "7441" };
            _calcManager = new CalculationManager(new MockRepositoryWrapper());

            var ex = Assert.Throws<ArgumentException>(() => _calcManager.Calculate(taxCalc));

            Assert.That(ex.Message == "Invalid negative annual income amount");
        }
    }
}