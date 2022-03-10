using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineShopping.DTOs;

public record CreateOrderProductDTO
{
    [JsonPropertyName("order_id")]
    [Required]
    public long OrderId { get; set; }

    [JsonPropertyName("Product_id")]
    [Required]
    public long ProductId { get; set; }


  
}

