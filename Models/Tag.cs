

using System.Text.Json.Serialization;
using OnlineShopping.DTOs;

namespace OnlineShopping.Models;

public record Tag
{
    /// <summary>
    /// Primary Key - NOT NULL, Unique, Index is Available
    // /// </summary>
  
    public long TagId { get; set; }
    

    public long ProductId { get; set; }
  
    public string Brand { get; set; }
    

    public string Color { get; set; }
    
    public string Material { get; set; }
   
    public long Weigth { get; set; }






    // public TagDTO asDto => new TagDTO
    // {
    //     ProductId=ProductId,

    //     Brand = Brand,
    //     Price = Price,
    //     Discount = Discount,
    //     ProductType = ProductType,
    //     Description= Description
    // };
}