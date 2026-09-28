using Part3_BuilderPattern;

var invoice = new InvoiceBuilder()
    .SetInvoiceId(1)
    .SetCustomerName("Mahmoud")
    .SetCustomerEmail("test@gmail.com")
    .SetBillingAddress("Cairo")
    .SetShippingAddress("Giza")
    .SetOrderDate(DateTime.Now)
    .SetCurrency("EGP")
    .SetSubTotal(1000)
    .SetTotalAmount(1000)
    .Build();

Console.WriteLine(invoice.CustomerName);
Console.WriteLine(invoice.TotalAmount);