namespace PS.Data
{
    public class TaxRate
    {
        public int Id { get; set; }
        public int Rate { get; set; }

        public decimal From { get; set; }

        public decimal To { get; set; }
    }
}
