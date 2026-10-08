# Part 3 — Builder Pattern Answers

## Task 3.1 — The Problem

### 1. Why is a 20-parameter constructor problematic?

A constructor with around 20 parameters is difficult to read and understand at the call site

It is also easy to pass arguments in the wrong order especially when several parameters have the same type, such as multiple strings or decimal values

For example when many string parameters are passed to a constructor it may not be immediately obvious which string represents the customer email, billing city, shipping city, or another value

Another problem is maintenance. If another property becomes necessary the constructor and its call sites may need to be changed, making the code harder to maintain

### 2. Is the problem only constructor length?

No.

The deeper problem is that the class contains many loosely related responsibilities and properties

For example customer information, billing information, shipping information, and order/payment information are different conceptual groups

Putting all of these concerns into one large object makes the design harder to understand and maintain

Splitting the related information into smaller objects gives each part a clearer responsibility

---

## Task 3.2 — Builder Pattern

The Builder Pattern separates the construction of a complex object from the final object itself

Instead of passing many values through one large constructor the caller can set the required values step by step using descriptive methods and finally call `Build()`

For example:

```csharp
var order = new OrderBuilder()
    .SetOrderDate(DateTime.Now)
    .SetPaymentMethod("Credit Card")
    .SetCurrency("EGP")
    .SetSubTotal(60000m)
    .SetDiscountAmount(1000m)
    .SetTaxAmount(5900m)
    .SetTotalAmount(64900m)
    .Build();


## Task 3.3 — Composed Builders

Instead of making `InvoiceBuilder` responsible for constructing every part of the invoice the construction is divided into smaller builders

`AddressBuilder` is responsible for constructing an `Address` and `OrderBuilder` is responsible for constructing an `Order`

The same `AddressBuilder` is reused to construct both the billing address and the shipping addres

`InvoiceBuilder` then composes these already-built objects together with the customer information to create the final `Invoice`

### Why is the composed design better?

#### 1. Single Responsibility Principle (SRP)

Each builder has one focused responsibility:

- `AddressBuilder` builds an `Address`
- `OrderBuilder` builds an `Order`
- `InvoiceBuilder` builds an `Invoice`

This prevents one large builder from being responsible for every part of the system

#### 2. Independent Validation

Each smaller builder can validate the information related to the object it constructs

For example, address-related validation can be handled when constructing an `Address` while order-related validation can be handled when constructing an `Order`

#### 3. Reuse

`AddressBuilder` can be reused for different addresses

For example, the same builder can create:

- The billing address
- The shipping address

There is no need to create a separate `BillingAddressBuilder` and `ShippingAddressBuilder`

#### 4. Call-Site Readability

The final construction becomes easier to understand because each part is constructed separately

```csharp
var billingAddress = new AddressBuilder()
    // billing address values
    .Build();

var shippingAddress = new AddressBuilder()
    // shipping address values
    .Build();

var order = new OrderBuilder()
    // order and payment values
    .Build();

var invoice = new InvoiceBuilder()
    // customer information
    .SetBillingAddress(billingAddress)
    .SetShippingAddress(shippingAddress)
    .SetOrder(order)
    .Build();