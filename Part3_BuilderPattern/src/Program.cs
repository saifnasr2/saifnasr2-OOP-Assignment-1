using Part3_BuilderPattern;

var billingAddress = new AddressBuilder()
    .SetStreet("Main Street")
    .SetCity("Mansoura")
    .SetState("Dakahlia")
    .SetZipCode("35511")
    .SetCountry("Egypt")
    .Build();

var shippingAddress = new AddressBuilder()
    .SetStreet("University Street")
    .SetCity("Mansoura")
    .SetState("Dakahlia")
    .SetZipCode("35516")
    .SetCountry("Egypt")
    .Build();

var order = new OrderBuilder()
    .SetOrderDate(DateTime.Now)
    .SetPaymentMethod("Credit Card")
    .SetCurrency("EGP")
    .SetSubTotal(60000m)
    .SetDiscountAmount(1000m)
    .SetTaxAmount(5900m)
    .SetTotalAmount(64900m)
    .Build();

var invoice = new InvoiceBuilder()
    .SetInvoiceId(1)
    .SetCustomerName("Saif Nasr")
    .SetCustomerEmail("saif@example.com")
    .SetCustomerPhone("01000000000")
    .SetBillingAddress(billingAddress)
    .SetShippingAddress(shippingAddress)
    .SetOrder(order)
    .Build();

Console.WriteLine("=== Invoice ===");
Console.WriteLine($"Invoice ID: {invoice.InvoiceId}");
Console.WriteLine($"Customer: {invoice.CustomerName}");
Console.WriteLine($"Email: {invoice.CustomerEmail}");
Console.WriteLine($"Billing City: {invoice.BillingAddress.City}");
Console.WriteLine($"Shipping City: {invoice.ShippingAddress.City}");
Console.WriteLine($"Payment Method: {invoice.Order.PaymentMethod}");
Console.WriteLine($"Currency: {invoice.Order.Currency}");
Console.WriteLine($"Subtotal: {invoice.Order.SubTotal}");
Console.WriteLine($"Discount: {invoice.Order.DiscountAmount}");
Console.WriteLine($"Tax: {invoice.Order.TaxAmount}");
Console.WriteLine($"Total: {invoice.Order.TotalAmount}");