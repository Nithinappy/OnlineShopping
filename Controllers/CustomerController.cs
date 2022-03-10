
using OnlineShopping.Repositories;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.DTOs;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers;

[ApiController]
[Route("api/customer")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly ICustomerRepository _customer;
    private readonly IOrderRepository _order;

    public CustomerController(ILogger<CustomerController> logger, ICustomerRepository customer, IOrderRepository order)
    {
        _logger = logger;
        _customer = customer;
        _order = order;
    }

    [HttpGet]
    public async Task<ActionResult<List<CustomerDTO>>> GetAllUsers()
    {
        var usersList = await _customer.GetList();

        // User -> CustomerDTO
        var dtoList = usersList.Select(x => x.asDto);

        return Ok(dtoList);
    }

    [HttpGet("{customer_id}")]
    public async Task<ActionResult<CustomerDTO>> GetCustomerById([FromRoute] long customer_id)
    {
        CustomerDTO customerDto = new CustomerDTO();
        var user = await _customer.GetById(customer_id);

        if (user is null)
            return NotFound("No Customer found with given Customer Id");

        customerDto = user.asDto;
        customerDto.MyOrders = await _order.GetCustomerOrderById(customer_id);
        // customerDto.MyProducts = await _order.CustomerProductOrderById(customer_id);
        
        
        return Ok(customerDto);
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDTO>> CreateUser([FromBody] CustomerCreateDTO Data)
    {


        var toCreateCustomer = new Customer
        {
            FirstName = Data.FirstName.Trim(),
            LastName = Data.LastName.Trim(),
            Email = Data.Email.Trim().ToLower(),
            Mobile = Data.Mobile,
            Address = Data.Address,
            Passcode = Data.Passcode
        };

        var createdUser = await _customer.Create(toCreateCustomer);

        return StatusCode(StatusCodes.Status201Created, createdUser.asDto);
    }

    [HttpPut("{customer_id}")]
    public async Task<ActionResult> UpdateCustomer([FromRoute] long customer_id,
    [FromBody] CustomerUpdateDTO Data)
    {
        var existing = await _customer.GetById(customer_id);
        if (existing is null)
            return NotFound("No Customer found with given Customer Id");

        var toUpdateCustomer = existing with
        {
            FirstName = Data.FirstName?.Trim() ?? existing.LastName,
            LastName = Data.LastName?.Trim() ?? existing.LastName,
            Mobile = Data.Mobile ?? existing.Mobile,


        };

        var didUpdate = await _customer.Update(toUpdateCustomer);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update user");

        return NoContent();
    }

    [HttpDelete("{customer_id}")]
    public async Task<ActionResult> DeleteUser([FromRoute] long customer_id)
    {
        var existing = await _customer.GetById(customer_id);
        if (existing is null)
            return NotFound("No Customer found with given Customer Id");

        var didDelete = await _customer.Delete(customer_id);

        return NoContent();
    }
}
