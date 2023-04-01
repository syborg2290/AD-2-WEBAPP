namespace AD2_WEB_APP.Models.OrderItem;

using System.ComponentModel.DataAnnotations;
using AD2_WEB_APP.Entities;

public class CreateRequestOrderItem
{

    [Required]
    public int OrderID { get; set; }

    [Required]
    public int ItemID { get; set; }

    [Required]
    public int Quantity { get; set; }

}