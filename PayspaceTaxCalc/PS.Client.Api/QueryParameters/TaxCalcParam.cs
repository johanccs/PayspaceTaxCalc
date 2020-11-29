namespace PS.Client.ServicesApi.QueryParameters
{
    public static class TaxCalcParam
    {
        public class Get
        {
            #region Properties

            public decimal AnnualIncome { get; private set; }
            public string PostalCode { get; private set; }

            #endregion

            #region Constructor

            public Get(decimal annualIncome, string postalCode)
            {
                AnnualIncome = annualIncome;
                PostalCode = postalCode;
            }

            #endregion
        }
    }
}
