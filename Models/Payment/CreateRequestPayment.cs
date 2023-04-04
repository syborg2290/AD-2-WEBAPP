namespace AD2_WEB_APP.Models.Payment;

using System.ComponentModel.DataAnnotations;
using AD2_WEB_APP.Entities;

public class CreateRequestPayment
{

    [Required]
    public int OrderID { get; set; }

    [Required]
    public double Amount { get; set; }

    [Required]
    public string PaymentDate { get; set; }

}