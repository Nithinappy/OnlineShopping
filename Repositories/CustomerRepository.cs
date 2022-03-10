using OnlineShopping.Models;
using Dapper;
using OnlineShopping.Utilities;

namespace OnlineShopping.Repositories;

public interface ICustomerRepository
{
    Task<Customer> Create(Customer Item);
    Task<bool> Update(Customer Item);
    Task<bool> Delete(long EmployeeNumber);
    Task<Customer> GetById(long customer_id);
    Task<List<Customer>> GetList();

}
public class CustomerRepository : BaseRepository, ICustomerRepository
{
    public CustomerRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<Customer> Create(Customer Item)
    {
        var query = $@"INSERT INTO ""{TableNames.customer}"" 
        (first_name, last_name, email, mobile, address, passcode) 
        VALUES (@FirstName, @LastName, @Email, @Mobile, @Address, @Passcode) 
        RETURNING *";

        using (var con = NewConnection)
        {
            var res = await con.QuerySingleOrDefaultAsync<Customer>(query, Item);
            return res;
        }
    }

    public async Task<bool> Delete(long CustomerId)
    {
        var query = $@"DELETE FROM ""{TableNames.customer}"" 
        WHERE customer_id = @CustomerId";

        using (var con = NewConnection)
        {
            var res = await con.ExecuteAsync(query, new { CustomerId });
            return res > 0;
        }
    }

    public async Task<Customer> GetById(long CustomerId)
    {
        var query = $@"SELECT * FROM ""{TableNames.customer}"" 
        WHERE customer_id = @CustomerId";
        // SQL-Injection

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Customer>(query, new { CustomerId });
    }

    public async Task<List<Customer>> GetList()
    {
        // Query
        var query = $@"SELECT * FROM ""{TableNames.customer}""";

        List<Customer> res;
        using (var con = NewConnection) // Open connection
            res = (await con.QueryAsync<Customer>(query)).AsList(); // Execute the query
        // Close the connection

        // Return the result
        return res;
    }

    public async Task<bool> Update(Customer Item)
    {
        var query = $@"UPDATE ""{TableNames.customer}"" SET first_name = @FirstName, 
        last_name = @LastName,mobile=@Mobile WHERE customer_id = @CustomerId";

        using (var con = NewConnection)
        {
            var rowCount = await con.ExecuteAsync(query, Item);
            return rowCount == 1;
        }
    }
}