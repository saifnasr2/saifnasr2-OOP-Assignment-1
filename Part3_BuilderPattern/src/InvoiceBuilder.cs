namespace Part3_BuilderPattern;

public class InvoiceBuilder
{
    private int _invoiceId;
    private string _customerName = string.Empty;
    private string _customerEmail = string.Empty;
    private string _customerPhone = string.Empty;

    private Address? _billingAddress;
    private Address? _shippingAddress;
    private Order? _order;

    public InvoiceBuilder SetInvoiceId(int invoiceId)
    {
        _invoiceId = invoiceId;
        return this;
    }

    public InvoiceBuilder SetCustomerName(string customerName)
    {
        _customerName = customerName;
        return this;
    }

    public InvoiceBuilder SetCustomerEmail(string customerEmail)
    {
        _customerEmail = customerEmail;
        return this;
    }

    public InvoiceBuilder SetCustomerPhone(string customerPhone)
    {
        _customerPhone = customerPhone;
        return this;
    }

    public InvoiceBuilder SetBillingAddress(Address billingAddress)
    {
        _billingAddress = billingAddress;
        return this;
    }

    public InvoiceBuilder SetShippingAddress(Address shippingAddress)
    {
        _shippingAddress = shippingAddress;
        return this;
    }

    public InvoiceBuilder SetOrder(Order order)
    {
        _order = order;
        return this;
    }

    public Invoice Build()
    {
        ArgumentNullException.ThrowIfNull(_billingAddress);
        ArgumentNullException.ThrowIfNull(_shippingAddress);
        ArgumentNullException.ThrowIfNull(_order);

        return new Invoice(
            _invoiceId,
            _customerName,
            _customerEmail,
            _customerPhone,
            _billingAddress,
            _shippingAddress,
            _order);
    }
}