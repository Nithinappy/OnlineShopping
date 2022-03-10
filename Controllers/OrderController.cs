
using OnlineShopping.Repositories;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.DTOs;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly ILogger<TagController> _logger;
    private readonly IOrderRepository _order;
    private readonly ICustomerRepository _customer;

    public OrderController(ILogger<TagController> logger, IOrderRepository order, ICustomerRepository customer)
    {
        _logger = logger;
        _order = order;
        _customer = customer;
    }

    [HttpPost]
    public async Task<ActionResult<Order>> CreateTag([FromBody] OrderCreateDTO Data)
    {
        var user = await _customer.GetById(Data.CustomerId);
        if (user is null)
            return NotFound("No Customer found with given Customer Id");

        var toCreateOrder = new Order
        {
            CustomerId = Data.CustomerId,
            OrderStatus = Data.OrderStatus,
            OrderDate = Data.OrderDate.UtcDateTime

        };

        var createdTag = await _order.CreateOrder(toCreateOrder);

        return StatusCode(StatusCodes.Status201Created, createdTag);
    }

    [HttpGet("{order_id}")]
    public async Task<ActionResult<ProductDTO>> GetOrderById([FromRoute] long order_id)
    {
        OrderDTO responseDto = new OrderDTO();
        var order = await _order.GetOrderById(order_id);

        if (order is null)
            return NotFound("No Order found with given Order Id");

        responseDto = order.asDto;
        responseDto.products = await _order.CustomerProductOrderById(order_id);

        return Ok(responseDto);
    }


    [HttpDelete("{order_id}")]
    public async Task<ActionResult> DeleteTag([FromRoute] long order_id)
    {
        var existing = await _order.GetOrderById(order_id);

        if (existing is null)
            return NotFound("No Order found with given Order Id");

        await _order.DeleteOrder(order_id);

        return NoContent();
    }

}