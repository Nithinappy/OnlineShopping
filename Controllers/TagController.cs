
using OnlineShopping.Repositories;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.DTOs;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers;

[ApiController]
[Route("api/tags")]
public class TagController : ControllerBase
{
    private readonly ILogger<TagController> _logger;
    private readonly ITagRepository _tag;
    private readonly IProductRepository _product;

    public TagController(ILogger<TagController> logger, ITagRepository tag, IProductRepository product)
    {
        _logger = logger;
        _tag = tag;
        _product = product;
    }

    [HttpPost]
    public async Task<ActionResult<Tag>> CreateTag([FromBody] TagCreateDTO Data)
    {
        var user = await _product.GetProductById(Data.ProductId);
        if (user is null)
            return NotFound("No Product found with given Product id");

        var toCreateTag = new Tag
        {
            ProductId = Data.ProductId,
            Brand = Data.Brand,
            Color = Data.Color,
            Material = Data.Material.Trim(),
            Weigth = Data.Weigth
        };

        var createdTag = await _tag.CreateTag(toCreateTag);

        return StatusCode(StatusCodes.Status201Created, createdTag);
    }

    [HttpPut("{tag_id}")]
    public async Task<ActionResult> UpdateTag([FromRoute] long tag_id,
    [FromBody] TagCreateDTO Data)
    {
         var existing = await _tag.GetTagById(tag_id);
        if (existing is null)
            return NotFound("No Tag found with given Tag Id");

        var toUpdateTag = existing with
        {
            ProductId = Data.ProductId,
            Brand = Data.Brand,
            Color = Data.Color,
            Material = Data.Material.Trim(),
            Weigth = Data.Weigth
        };



        await _tag.UpdateTag(toUpdateTag);

        return NoContent();
    }

    [HttpDelete("{tag_id}")]
    public async Task<ActionResult> DeleteTag([FromRoute] long tag_id)
    {
        var existing = await _tag.GetTagById(tag_id);

        if (existing is null)
            return NotFound("No Tag found with given Tag Id");

        await _tag.DeleteTag(tag_id);

        return NoContent();
    }

}