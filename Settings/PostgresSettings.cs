namespace OnlineShopping.Settings;

public class PostgresSettings
{
    //  "Host": "localhost",
    //   "Port": 5432,
    //   "Username": "product_admin",
    //   "Password": "root",
    //   "Database": "onlineshopping"

    public string Host { get; set; }
    public int Port { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Database { get; set; }
    public string ConnectionString { get => $"Host={Host};Port={Port};Username={Username};Password={Password};Database={Database};Include Error Detail=true"; }
}