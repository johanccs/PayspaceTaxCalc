using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PS.Data
{
    [Table("TaxResult")]
    public class TaxResult
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
        [Required (ErrorMessage = "Result value is required")]
        [DataType(DataType.Currency)]
        public decimal Result { get; set; }
        [Required (ErrorMessage = "Date is required")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        [Required (ErrorMessage = "Annual income is required")]
        [DataType (DataType.Currency)]
        public decimal AnnualIncome { get; set; }
        [Required(ErrorMessage = "Postal Code is required")]
        [StringLength(4, ErrorMessage = "Postal Code cannot be longer than 4 characters")]
        public string  PostalCode { get; set; }
    }
}
