namespace AD2_WEB_APP.Models.Order;

using System.ComponentModel.DataAnnotations;
using AD2_WEB_APP.Entities;

public class CreateRequestOrder
{

    [Required]
    public int CustomerID { get; set; }

    [Required]
    public int ShippingAddressID { get; set; }

    [Required]
    public int BillingAddressID { get; set; }

    [Required]
    public string Shipping_Method { get; set; }

    [Required]
    public string Shipping_Date { get; set; }

    [Required]
    public double TotalPrice { get; set; }

    [Required]
    public string OrderStatus { get; set; }

}