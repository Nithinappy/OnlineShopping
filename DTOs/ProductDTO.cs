using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using OnlineShopping.Models;

namespace OnlineShopping.DTOs;

public record ProductDTO
{
    [JsonPropertyName("product_id")]
    public long ProductId { get; set; }

    [JsonPropertyName("name")]
    public string ProductName { get; set; }

    [JsonPropertyName("price")]
    public float Price { get; set; }

    [JsonPropertyName("discount")]
    public int Discount { get; set; }

    [JsonPropertyName("type")]
    public string ProductType { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("tags")]
   public List<Tag> Tags { get; set; }
}

public record OrderProductDTO
{
    [JsonPropertyName("product_id")]
    public long ProductId { get; set; }

    [JsonPropertyName("name")]
    public string ProductName { get; set; }

    [JsonPropertyName("price")]
    public float Price { get; set; }

    [JsonPropertyName("discount")]
    public int Discount { get; set; }

    [JsonPropertyName("type")]
    public string ProductType { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
    
  
}

public record ProductCreateDTO
{

    [JsonPropertyName("product_name")]
    [Required]

    public string ProductName { get; set; }

    [JsonPropertyName("price")]

    [Required]
    public float Price { get; set; }

    [JsonPropertyName("discount")]

    public int Discount { get; set; }

    [JsonPropertyName("product_type")]
    [Required]

    public string ProductType { get; set; }

    [JsonPropertyName("description")]
    [Required]
    public string Description { get; set; }




}

public record ProductUpdateDTO
{
   
    [JsonPropertyName("product_name")]
    

    public string ProductName { get; set; }

    [JsonPropertyName("price")]

    
    public float? Price { get; set; }

    [JsonPropertyName("discount")]

    public int? Discount { get; set; }

    [JsonPropertyName("product_type")]
    

    public string ProductType { get; set; }

    [JsonPropertyName("description")]
    
    public string Description { get; set; }



}