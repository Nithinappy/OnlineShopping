

using OnlineShopping.DTOs;

namespace OnlineShopping.Models;

public record Customer
{
    /// <summary>
    /// Primary Key - NOT NULL, Unique, Index is Available
    /// </summary>
    public long CustomerId { get; set; }
    public string FirstName { get; set; }
    /// <summary>
    /// Can be NULL
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// Can be UNIQUE
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// Can be UNIQUE
    /// </summary>
    public long Mobile { get; set; }

    
    /// <summary>
    /// Cannot be NULL
    /// </summary>
    public string Address { get; set; }

   /// <summary>
    /// Cannot be NULL
    /// </summary>
    public string Passcode { get; set; }


    public CustomerDTO asDto => new CustomerDTO
    {
        CustomerId = CustomerId,
        FirstName = FirstName,
        LastName = LastName,
        Mobile = Mobile,
        Email = Email,
        Address= Address
    };
}