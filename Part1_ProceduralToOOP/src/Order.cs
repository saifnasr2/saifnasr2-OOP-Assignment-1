using System;

namespace Part1_ProceduralToOOP;

public class Order
{
    public int Id {get; }
    public Customer Customer {get; }
    public DateTime Date {get; }
    public bool IsPaid {get; private set; } = false;

    private readonly List<OrderLine> _orderLines = new();
    public IReadOnlyList<OrderLine> OrderLines => _orderLines;

    public Order(int id, Customer customer, DateTime date)
    {
        ArgumentNullException.ThrowIfNull(customer);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
        

        Id = id;
        Customer = customer;
        Date = date;
        
    }

    public void AddLine(Product product , int quantity)
    {
     ArgumentNullException.ThrowIfNull(product);
     ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);

        if (IsPaid)
        {
            throw new InvalidOperationException("Cannot add a line to a paid order.");
        }   

        product.ReduceStock(quantity);

        var orderLine = new OrderLine(product , quantity);
        _orderLines.Add(orderLine);
    }

    public void Pay()
    {
    if (_orderLines.Count == 0)
        throw new InvalidOperationException("Cannot pay an empty order.");

    if (IsPaid)
        throw new InvalidOperationException("Order is already paid.");

    IsPaid = true;
    }

    public decimal CalculateTotal()
    {
    decimal total = 0;

    foreach (var line in _orderLines)
    {
        total += line.Product.Price * line.Quantity;
    }

    if (Customer.IsVip)
        total *= 0.90m;

    return total;
    }
}
