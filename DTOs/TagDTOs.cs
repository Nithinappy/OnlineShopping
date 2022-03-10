using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineShopping.DTOs;
// 	product_id BIGINT NOT NULL,
// brand   VARCHAR(50) NOT NULL,
// color VARCHAR(50) NOT NULL,
// material VARCHAR(50) NOT NULL,
// weigth BIGINT NOT NULL,
// public record TagDTO
// {
//     [JsonPropertyName("product_id")]
//     public long ProductId { get; set; }

//     [JsonPropertyName("product_id")]
//     public string ProductName { get; set; }

//     [JsonPropertyName("brand")]
//     public string Brand { get; set; }

//     [JsonPropertyName("color")]
//     public string Color { get; set; }

//     [JsonPropertyName("material")]
//     public string Material { get; set; }

//     [JsonPropertyName("weigth")]
//     public string Weigth { get; set; }
// }

public record TagCreateDTO
{
    [JsonPropertyName("product_id")]
    [Required]
    public long ProductId { get; set; }


    [JsonPropertyName("brand")]
    [Required]

    public string Brand { get; set; }

    [JsonPropertyName("color")]
    [Required]

    public string Color { get; set; }

    [JsonPropertyName("material")]
    [Required]

    public string Material { get; set; }

    [JsonPropertyName("weigth")]
    [Required]

    public long Weigth { get; set; }

}

public record TagUpdateDTO
{

    [JsonPropertyName("product_id")]
    [Required]
    public long ProductId { get; set; }


    [JsonPropertyName("brand")]
    [Required]

    public string Brand { get; set; }

    [JsonPropertyName("color")]
    [Required]

    public string Color { get; set; }

    [JsonPropertyName("material")]
    [Required]

    public string Material { get; set; }

    [JsonPropertyName("weigth")]
    [Required]

    public long Weigth { get; set; }



}