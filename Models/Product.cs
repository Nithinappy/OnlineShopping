

using System.Text.Json.Serialization;
using OnlineShopping.DTOs;

namespace OnlineShopping.Models;

public record Product
{
    /// <summary>
    /// Primary Key - NOT NULL, Unique, Index is Available
    /// </summary>
   
    public long ProductId { get; set; }
   
    public string ProductName { get; set; }
    
   public float Price { get; set; }
   

   public int Discount{get;set;}
  

   public string ProductType { get; set; }
    

   public string Description{get;set;}


   
   
   
   


    public ProductDTO asDto => new ProductDTO
    {
        ProductId = ProductId,
        ProductName = ProductName,
        Price = Price,
        Discount = Discount,
        ProductType = ProductType,
        Description= Description
    };
}