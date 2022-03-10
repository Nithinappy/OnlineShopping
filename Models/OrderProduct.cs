

using System.Text.Json.Serialization;
using OnlineShopping.DTOs;

namespace OnlineShopping.Models;

public record OrderProduct
{
  
    public long OrderId { get; set; }
    

    public long ProductId { get; set; }
     

}