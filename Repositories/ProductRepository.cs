using OnlineShopping.Models;
using Dapper;
using OnlineShopping.Utilities;

namespace OnlineShopping.Repositories;

public interface IProductRepository
{
    Task<Product> CreateProduct(Product Item);
    Task<bool> UpdateProduct(Product Item);
    Task<bool> DeleteProduct(long ProductId);
    Task<Product> GetProductById(long ProductId);
    Task<List<Product>> GetProductList();

}
public class ProductRepository : BaseRepository, IProductRepository
{
    public ProductRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<Product> CreateProduct(Product Item)
    {
        var query = $@"INSERT INTO ""{TableNames.product}"" 
        (product_name, price,discount,product_type, description) 
        VALUES (@ProductName, @Price, @Discount, @ProductType, @Description) 
        RETURNING *";

        using (var con = NewConnection)
        {
            var res = await con.QuerySingleOrDefaultAsync<Product>(query, Item);
            return res;
        }
    }

    public async Task<bool> DeleteProduct(long ProductId)
    {
        var query = $@"Delete  FROM ""{TableNames.product}"" 
        WHERE Product_id = @ProductId";

        using (var con = NewConnection)
        {
            var res = await con.ExecuteAsync(query, new { ProductId });
            return res > 0;
        }
    }

    public async Task<Product> GetProductById(long ProductId)
    {
        var query = $@"SELECT * FROM ""{TableNames.product}"" 
        WHERE Product_id = @ProductId";
        // SQL-Injection

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Product>(query, new { ProductId });
    }

    public async Task<List<Product>> GetProductList()
    {
        // Query
        var query = $@"SELECT * FROM ""{TableNames.product}""";

        List<Product> res;
        using (var con = NewConnection) // Open connection
            res = (await con.QueryAsync<Product>(query)).AsList(); // Execute the query
        // Close the connection

        // Return the result
        return res;
    }

    public async Task<bool> UpdateProduct(Product Item)
    {
        var query = $@"Update ""{TableNames.product}"" SET product_name = @ProductName, 
        price = @Price,discount=@Discount,product_type=@ProductType,description=@Description WHERE Product_id = @ProductId";

        using (var con = NewConnection)
        {
            var rowCount = await con.ExecuteAsync(query, Item);
            return rowCount == 1;
        }
    }
}