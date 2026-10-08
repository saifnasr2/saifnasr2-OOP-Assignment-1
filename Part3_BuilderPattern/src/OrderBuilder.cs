namespace Part3_BuilderPattern;

public class OrderBuilder
{
    private DateTime _orderDate;
    private string _paymentMethod = string.Empty;
    private string _currency = string.Empty;
    private decimal _subTotal;
    private decimal _discountAmount;
    private decimal _taxAmount;
    private decimal _totalAmount;

    public OrderBuilder SetOrderDate(DateTime orderDate)
    {
        _orderDate = orderDate;
        return this;
    }

    public OrderBuilder SetPaymentMethod(string paymentMethod)
    {
        _paymentMethod = paymentMethod;
        return this;
    }

    public OrderBuilder SetCurrency(string currency)
    {
        _currency = currency;
        return this;
    }

    public OrderBuilder SetSubTotal(decimal subTotal)
    {
        _subTotal = subTotal;
        return this;
    }

    public OrderBuilder SetDiscountAmount(decimal discountAmount)
    {
        _discountAmount = discountAmount;
        return this;
    }

    public OrderBuilder SetTaxAmount(decimal taxAmount)
    {
        _taxAmount = taxAmount;
        return this;
    }

    public OrderBuilder SetTotalAmount(decimal totalAmount)
    {
        _totalAmount = totalAmount;
        return this;
    }

    public Order Build()
    {
        return new Order(
            _orderDate,
            _paymentMethod,
            _currency,
            _subTotal,
            _discountAmount,
            _taxAmount,
            _totalAmount);
    }
}