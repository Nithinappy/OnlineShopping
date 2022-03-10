
using OnlineShopping.Repositories;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.DTOs;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductRepository _product;
    private readonly ITagRepository _tag;

    public ProductController(ILogger<ProductController> logger, IProductRepository product, ITagRepository tag)
    {
        _logger = logger;
        _product = product;
        _tag = tag;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductDTO>>> GetAllProducts()
    {
        var productList = await _product.GetProductList();


        var dtoList = productList.Select(x => x.asDto);

        return Ok(dtoList);
    }

    [HttpGet("{product_id}")]
    public async Task<ActionResult<ProductDTO>> GetProductById([FromRoute] long product_id)
    {
        var product = await _product.GetProductById(product_id);

        if (product is null)
            return NotFound("No Product found with given Product Id");
        var dto = product.asDto;
        dto.Tags = await _tag.GetAllProductList(product_id);

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDTO>> CreateProduct([FromBody] ProductCreateDTO Data)
    {


        var toCreateProduct = new Product
        {
            ProductName = Data.ProductName.Trim(),
            Price = Data.Price,
            Discount = Data.Discount,
            ProductType = Data.ProductType.Trim(),
            Description = Data.Description
        };

        var createdProduct = await _product.CreateProduct(toCreateProduct);

        return StatusCode(StatusCodes.Status201Created, createdProduct.asDto);
    }

    [HttpPut("{product_id}")]
    public async Task<ActionResult> UpdateProduct([FromRoute] long product_id,
    [FromBody] ProductUpdateDTO Data)
    {
        var existing = await _product.GetProductById(product_id);
        if (existing is null)
            return NotFound("No Product found with given Product Id");

        var toUpdateProduct = existing with
        {

            ProductName = Data.ProductName.Trim() ?? existing.ProductName,
            Price = Data.Price ?? existing.Price,
            Discount = Data.Discount ?? existing.Discount,
            ProductType = Data.ProductType.Trim() ?? existing.ProductType,
            Description = Data.Description ?? existing.Description

        };

        var didUpdate = await _product.UpdateProduct(toUpdateProduct);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update Product");

        return NoContent();
    }

    [HttpDelete("{product_id}")]
    public async Task<ActionResult> DeleteProduct([FromRoute] long product_id)
    {
        var existing = await _product.GetProductById(product_id);
        if (existing is null)
            return NotFound("No Product found with given Product Id");

        var didDelete = await _product.DeleteProduct(product_id);

        return NoContent();
    }
}
