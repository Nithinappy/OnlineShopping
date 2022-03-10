using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using OnlineShopping.Models;

namespace OnlineShopping.DTOs;

public record CustomerDTO
{
    [JsonPropertyName("customer_id")]
    public long CustomerId { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("mobile")]
    public long Mobile { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }

    public List<OrderDTO> MyOrders { get; set; }
    // public List<Product> MyProducts { get; set; }

}

public record CustomerCreateDTO
{
    [JsonPropertyName("first_name")]
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    [MaxLength(50)]
    [Required]
    public string LastName { get; set; }

    [JsonPropertyName("email")]
    [MaxLength(255)]
    public string Email { get; set; }

    [JsonPropertyName("mobile")]
    [Required]
    public long Mobile { get; set; }

    [JsonPropertyName("address")]
    [Required]
    public string Address { get; set; }
 
    [JsonPropertyName("passcode")]
    [Required]
    [MaxLength(15)]
    public string Passcode { get; set; } 

   
}

public record CustomerUpdateDTO
{
     [JsonPropertyName("first_name")]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    [MaxLength(50)]
    public string LastName { get; set; }

    [JsonPropertyName("mobile")]
    public long? Mobile { get; set; } = null;


}