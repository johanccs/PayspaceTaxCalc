using System.ComponentModel.DataAnnotations;

namespace PS.Client.Web.Models
{
    public class TaxCalculationModel
    {
        [Required(ErrorMessage = "Annual Income is required")]
        public decimal AnnualIncome { get; set; }

        [Required(ErrorMessage = "Postal Code is required")]
        [StringLength(4, ErrorMessage = "Postal Code cannot be longer than 4 characters")]
        public string PostalCode { get; set; }
    }
}
