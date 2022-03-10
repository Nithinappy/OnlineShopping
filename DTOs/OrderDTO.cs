using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using OnlineShopping.Models;

namespace OnlineShopping.DTOs;
public record OrderDTO
{

    [JsonPropertyName("customer_id")]
   
    public long CustomerId { get; set; }


    [JsonPropertyName("order_status")]
  

    public string OrderStatus { get; set; }

    [JsonPropertyName("order_date")]
   

    public DateTimeOffset OrderDate { get; set; }

 [JsonPropertyName("order_Products")]
     public List<ProductDTO> products { get; set; }


}

public record OrderCreateDTO
{

    [JsonPropertyName("customer_id")]
    [Required]
    public long CustomerId { get; set; }


    [JsonPropertyName("order_status")]
    [Required]

    public string OrderStatus { get; set; }

    [JsonPropertyName("order_date")]
    [Required]

    public DateTimeOffset OrderDate { get; set; }


}

