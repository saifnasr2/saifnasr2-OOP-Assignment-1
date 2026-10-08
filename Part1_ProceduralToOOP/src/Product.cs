namespace Part1_ProceduralToOOP;

public class Product
{
    public int Id {get; }
    public string Name {get; }
    public decimal Price {get; }
    public int Stock {get; private set; }
    
    
    public Product(int id, string name, decimal price, int stock)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
        ArgumentNullException.ThrowIfNullOrEmpty(name);
        ArgumentOutOfRangeException.ThrowIfNegative(stock);
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
    }

    public void ReduceStock(int quantity)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(quantity, Stock);
        Stock -= quantity;
    }
}
