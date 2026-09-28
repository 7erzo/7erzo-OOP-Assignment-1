namespace Part3_BuilderPattern;

public class InvoiceBuilder
{
    private int _invoiceId;
    private string _customerName;
    private string _customerEmail;
    private string? _customerPhone;

    private string _billingAddress;
    private string _shippingAddress;

    private DateTime _orderDate;
    private string? _paymentMethod;
    private string _currency;

    private decimal _subTotal;
    private decimal _discountAmount;
    private decimal _taxAmount;
    private decimal _totalAmount;

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

    public InvoiceBuilder SetCustomerPhone(string? customerPhone)
    {
        _customerPhone = customerPhone;
        return this;
    }

    public InvoiceBuilder SetBillingAddress(string billingAddress)
    {
        _billingAddress = billingAddress;
        return this;
    }

    public InvoiceBuilder SetShippingAddress(string shippingAddress)
    {
        _shippingAddress = shippingAddress;
        return this;
    }

    public InvoiceBuilder SetOrderDate(DateTime orderDate)
    {
        _orderDate = orderDate;
        return this;
    }

    public InvoiceBuilder SetPaymentMethod(string? paymentMethod)
    {
        _paymentMethod = paymentMethod;
        return this;
    }

    public InvoiceBuilder SetCurrency(string currency)
    {
        _currency = currency;
        return this;
    }

    public InvoiceBuilder SetSubTotal(decimal subTotal)
    {
        _subTotal = subTotal;
        return this;
    }

    public InvoiceBuilder SetDiscountAmount(decimal discountAmount)
    {
        _discountAmount = discountAmount;
        return this;
    }

    public InvoiceBuilder SetTaxAmount(decimal taxAmount)
    {
        _taxAmount = taxAmount;
        return this;
    }

    public InvoiceBuilder SetTotalAmount(decimal totalAmount)
    {
        _totalAmount = totalAmount;
        return this;
    }
    public Invoice Build()
    {
        if (string.IsNullOrWhiteSpace(_customerName))
        {
            throw new InvalidOperationException("Customer name is required.");
        }

        if (string.IsNullOrWhiteSpace(_customerEmail))
        {
            throw new InvalidOperationException("Customer email is required.");
        }

        if (string.IsNullOrWhiteSpace(_billingAddress))
        {
            throw new InvalidOperationException("Billing address is required.");
        }

        if (string.IsNullOrWhiteSpace(_shippingAddress))
        {
            throw new InvalidOperationException("Shipping address is required.");
        }

        if (string.IsNullOrWhiteSpace(_currency))
        {
            throw new InvalidOperationException("Currency is required.");
        }
        if (_invoiceId <= 0)
        {
            throw new InvalidOperationException("Invoice ID is required.");
        }

        if (_orderDate == default)
        {
            throw new InvalidOperationException("Order date is required.");
        }

        if (_subTotal < 0)
        {
            throw new InvalidOperationException("Subtotal cannot be negative.");
        }

        if (_totalAmount < 0)
        {
            throw new InvalidOperationException("Total amount cannot be negative.");
        }
        return new Invoice(
            _invoiceId,
            _customerName,
            _customerEmail,
            _customerPhone,
            _billingAddress,
            _shippingAddress,
            _orderDate,
            _paymentMethod,
            _currency,
            _subTotal,
            _discountAmount,
            _taxAmount,
            _totalAmount
        );
    }
}