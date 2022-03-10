

using System.Text.Json.Serialization;
using OnlineShopping.DTOs;

namespace OnlineShopping.Models;

public record Order
{
    /// <summary>
    /// Primary Key - NOT NULL, Unique, Index is Available
    // /// </summary>

    public long OrderId { get; set; }


    public long CustomerId { get; set; }

    public string OrderStatus { get; set; }


    public DateTimeOffset OrderDate { get; set; }

   

      public OrderDTO asDto => new OrderDTO
    {
        CustomerId = CustomerId,
        OrderStatus = OrderStatus,
        OrderDate = OrderDate
    };


}