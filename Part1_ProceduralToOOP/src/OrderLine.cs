using System;

namespace Part1_ProceduralToOOP;

public class OrderLine
{
  

    public Product Product {get; }
    public int Quantity {get; }
    
    
    public OrderLine(Product product, int quantity)
    {
        ArgumentNullException.ThrowIfNull(product);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
        Product = product;
        Quantity = quantity;
    }
    
}
