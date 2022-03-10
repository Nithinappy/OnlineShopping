using OnlineShopping.Models;
using Dapper;
using OnlineShopping.Utilities;

namespace OnlineShopping.Repositories;

public interface ITagRepository
{
    Task<Tag> CreateTag(Tag Item);
    Task<bool> UpdateTag(Tag Item);
    Task<bool> DeleteTag(long TagId);
     Task<Tag> GetTagById(long TagId);
     Task<List<Tag>> GetAllProductList(long ProductId);

}
public class TagRepository : BaseRepository, ITagRepository
{
    public TagRepository(IConfiguration config) : base(config)
    {

    }

 public async Task<Tag> GetTagById(long TagId)
    {
        var query = $@"SELECT * FROM {TableNames.tags} 
        WHERE tag_id = @TagId";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Tag>(query, new { TagId });
    }
    public async Task<Tag> CreateTag(Tag Item)

    { var query = $@"INSERT INTO {TableNames.tags} (product_id,brand,color,
        material,weigth) VALUES (@ProductId, @Brand, @Color, @Material,@Weigth) 
        RETURNING *";

        using (var con = NewConnection)
        {
            var res = await con.QuerySingleOrDefaultAsync<Tag>(query, Item);
            return res;
        }
    }

    public async Task<bool> DeleteTag(long TagId)
    {
        var query = $@"Delete  FROM ""{TableNames.tags}"" 
        WHERE tag_id = @TagId";

        using (var con = NewConnection)
        {
            var res = await con.ExecuteAsync(query, new { TagId });
            return res > 0;
        }
    }

   
    public async Task<bool> UpdateTag(Tag Item)
    {
        var query = $@"Update ""{TableNames.tags}"" SET product_id=@ProductId, brand=@brand,color=@Color,material=@Material,weigth=@Weigth WHERE tag_id = @TagId";

        using (var con = NewConnection)
        {
            var rowCount = await con.ExecuteAsync(query, Item);
            return rowCount == 1;
        }
    }
     public async Task<List<Tag>> GetAllProductList(long ProductId)
    {
        var query = $@"SELECT * FROM {TableNames.tags} 
        WHERE product_id = @ProductId";

        using (var con = NewConnection)
            return (await con.QueryAsync<Tag>(query, new { ProductId })).AsList();
    }
}