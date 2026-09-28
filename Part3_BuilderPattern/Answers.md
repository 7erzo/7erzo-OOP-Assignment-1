# Part 3 — Builder Pattern

## Task 3.1 — Why Are 20-Parameter Constructors a Problem?

### Question 1

A constructor with 20 parameters is hard to read and understand at the call site.

When there are multiple parameters with the same type, such as decimal values or strings, it is easy to pass them in the wrong order. The code will still compile, but the data may be incorrect.

When we add a new parameter, we have to update the constructor and every place where the constructor is called.

### Question 2

The problem is deeper than just having a long constructor.

The class contains different types of data that can be split into meaningful groups, such as billing address, shipping address, and order/payment information.

Splitting these groups makes the design easier to understand and makes validation easier.

---

# Task 3.2 — Single Builder

The Builder Pattern allows us to create the Invoice step by step instead of passing many parameters to one constructor.

The builder provides fluent methods for setting the properties and uses `Build()` to create the final Invoice.

### Mandatory Properties

The following properties are mandatory:

- InvoiceId
- CustomerName
- CustomerEmail
- BillingAddress
- ShippingAddress
- OrderDate
- Currency
- SubTotal
- TotalAmount

The `Build()` method validates these properties before creating the Invoice.

If a mandatory property is missing or invalid, `Build()` throws a clear exception.

### Optional Properties

The following properties are optional:

- CustomerPhone
- PaymentMethod
- DiscountAmount
- TaxAmount

These properties can be left with their default values.

### Why Use the Builder?

The Builder improves:

- Readability
- Maintainability
- Validation
- Flexibility when adding new properties

Instead of passing many values to one constructor, the caller sets the properties step by step.

---

# Task 3.3 — Composed Builders

The single builder can still become large because it handles different groups of data.

To improve the design, the construction was split into smaller builders:

- `AddressBuilder`
- `OrderBuilder`
- `InvoiceBuilder`

## AddressBuilder

`AddressBuilder` is responsible only for creating and validating an `Address`.

It handles:

- Street
- City
- State
- ZipCode
- Country

The same `AddressBuilder` is used to create both the billing address and the shipping address.

## OrderBuilder

`OrderBuilder` is responsible only for creating and validating an `Order`.

It handles:

- OrderDate
- PaymentMethod
- Currency
- SubTotal
- DiscountAmount
- TaxAmount
- TotalAmount

It validates the order information independently from the address information.

## InvoiceBuilder

`InvoiceBuilder` is responsible for composing the smaller objects.

It combines:

- Customer information
- Billing `Address`
- Shipping `Address`
- `Order`

After all required information is provided, it creates the final `Invoice`.

---

# Why Is the Composed Version Better?

### 1. Single Responsibility

Each builder has one clear responsibility.

- `AddressBuilder` handles address creation and validation.
- `OrderBuilder` handles order and payment information.
- `InvoiceBuilder` combines the smaller objects into an Invoice.

This makes each part easier to understand and maintain.

### 2. Independent Validation

`AddressBuilder` can validate an address by itself.

`OrderBuilder` can validate order information by itself.

The `InvoiceBuilder` does not need to know the details of street, city, ZIP code, or order validation.

### 3. Reuse

The same `AddressBuilder` can be reused for both billing and shipping addresses.

Without it, we would have to duplicate the same address-building and validation logic.

### 4. Readability

The composed version makes the construction process easier to understand because related data is grouped into meaningful objects.

For example:

```csharp
var billingAddress = new AddressBuilder()
    .SetStreet("Tahrir Street")
    .SetCity("Cairo")
    .SetState("Cairo")
    .SetZipCode("11511")
    .SetCountry("Egypt")
    .Build();

var order = new OrderBuilder()
    .SetOrderDate(DateTime.Now)
    .SetCurrency("EGP")
    .SetSubTotal(1000)
    .SetTotalAmount(990)
    .Build();

var invoice = new InvoiceBuilder()
    .SetInvoiceId(1)
    .SetCustomerName("Mahmoud")
    .SetCustomerEmail("mahmoud@example.com")
    .SetBillingAddress(billingAddress)
    .SetShippingAddress(shippingAddress)
    .SetOrder(order)
    .Build();