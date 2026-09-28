using Part3_BuilderPattern;

var billingAddress = new AddressBuilder()
    .SetStreet("Tahrir Street")
    .SetCity("Cairo")
    .SetState("Cairo")
    .SetZipCode("11511")
    .SetCountry("Egypt")
    .Build();

var shippingAddress = new AddressBuilder()
    .SetStreet("Pyramids Street")
    .SetCity("Giza")
    .SetState("Giza")
    .SetZipCode("12511")
    .SetCountry("Egypt")
    .Build();

var order = new OrderBuilder()
    .SetOrderDate(DateTime.Now)
    .SetPaymentMethod("Visa")
    .SetCurrency("EGP")
    .SetSubTotal(1000)
    .SetDiscountAmount(100)
    .SetTaxAmount(90)
    .SetTotalAmount(990)
    .Build();

var invoice = new InvoiceBuilder()
    .SetInvoiceId(1)
    .SetCustomerName("Mahmoud")
    .SetCustomerEmail("mahmoud@example.com")
    .SetCustomerPhone("01012345678")
    .SetBillingAddress(billingAddress)
    .SetShippingAddress(shippingAddress)
    .SetOrder(order)
    .Build();

Console.WriteLine($"Invoice ID: {invoice.InvoiceId}");
Console.WriteLine($"Customer: {invoice.CustomerName}");
Console.WriteLine($"Billing City: {invoice.BillingAddress.City}");
Console.WriteLine($"Shipping City: {invoice.ShippingAddress.City}");
Console.WriteLine($"Total Amount: {invoice.Order.TotalAmount}");