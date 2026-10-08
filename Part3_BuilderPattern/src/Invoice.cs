namespace Part3_BuilderPattern;

public class Invoice
{
    // Billing / customer information
    public int InvoiceId { get; }
    public string CustomerName { get; }
    public string CustomerEmail { get; }
    public string CustomerPhone { get; }

    // Addresses
    public Address BillingAddress { get; }
    public Address ShippingAddress { get; }

    // Order / payment information
    public Order Order { get; }

    public Invoice(
        int invoiceId,
        string customerName,
        string customerEmail,
        string customerPhone,
        Address billingAddress,
        Address shippingAddress,
        Order order)
    {
        InvoiceId = invoiceId;
        CustomerName = customerName;
        CustomerEmail = customerEmail;
        CustomerPhone = customerPhone;
        BillingAddress = billingAddress;
        ShippingAddress = shippingAddress;
        Order = order;
    }
}