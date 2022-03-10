using OnlineShopping.Models;
using Dapper;
using OnlineShopping.Utilities;
using OnlineShopping.DTOs;

namespace OnlineShopping.Repositories;

public interface IOrderRepository
{
    Task<Order> CreateOrder(Order Item);
    Task<bool> DeleteOrder(long OrderId);
    Task<Order> GetOrderById(long OrderId);
    Task<List<Order>> GetAllOrderList(long ProductId);
    Task<List<OrderDTO>> GetCustomerOrderById(long CustomerId);
    Task<List<ProductDTO>> CustomerProductOrderById(long OrderId);

}
public class OrderRepository : BaseRepository, IOrderRepository
{
    public OrderRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<List<OrderDTO>> GetCustomerOrderById(long CustomerId)
    {
        var query = $@"SELECT * FROM ""{TableNames.order}""
         WHERE customer_id= @CustomerId";

        using var con = NewConnection;
        var response = await con.QueryAsync<OrderDTO>(query, new { CustomerId });
        var lstUsers = response.AsList();
        return lstUsers;
        // return (await con.QueryAsync<Order>(query, new { CustomerId })).AsList();
    }
    public async Task<Order> GetOrderById(long OrderId)
    {
        var query = $@"SELECT * FROM ""{TableNames.order}"" 
        WHERE order_id=@OrderId";
        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Order>(query, new { OrderId });
    }


    public async Task<Order> CreateOrder(Order Item)

    {
        var query = $@"INSERT INTO ""{TableNames.order}"" (customer_id,order_status,order_date)
     VALUES (@CustomerId,@OrderStatus,@OrderDate) 
        RETURNING *";

        using (var con = NewConnection)
        {
            var res = await con.QuerySingleOrDefaultAsync<Order>(query, Item);
            return res;
        }
    }

    public async Task<bool> DeleteOrder(long OrderId)
    {
        var query = $@"Delete  FROM ""{TableNames.order}"" 
        WHERE order_id=@OrderId";

        using (var con = NewConnection)
        {
            var res = await con.ExecuteAsync(query, new { OrderId });
            return res > 0;
        }
    }



    public async Task<List<Order>> GetAllOrderList(long ProductId)
    {
        var query = $@"SELECT * FROM {TableNames.order} 
        WHERE product_id = @ProductId";

        using (var con = NewConnection)
            return (await con.QueryAsync<Order>(query, new { ProductId })).AsList();
    }
public async Task<List<ProductDTO>> CustomerProductOrderById(long OrderId)
    {

        var query = $@"SELECT product.* FROM {TableNames.order_product}  orderprod INNER JOIN {TableNames.product} product 
			  on orderprod.product_id = product.product_id where orderprod.order_id =@OrderId order by product.product_id asc;
			  ";
       
        using (var con = NewConnection)
            return (await con.QueryAsync<ProductDTO>(query, new { OrderId })).AsList();
    }


}