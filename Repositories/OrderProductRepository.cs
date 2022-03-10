using OnlineShopping.Models;
using Dapper;
using OnlineShopping.Utilities;

namespace OnlineShopping.Repositories;
public interface IOrderProductRepository
{
   
    // Task<OrderProduct<Product>> GetProductList();

}
public class OrderProductRepository : BaseRepository, IOrderProductRepository
{
    public OrderProductRepository(IConfiguration config) : base(config)
    {

    }
}