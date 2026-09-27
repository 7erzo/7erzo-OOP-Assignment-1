namespace Part1_ProceduralToOOP;

public class Order
{
    public int Id { get; }
    public Customer Customer { get; }

    private readonly List<OrderLine> _orderLines = new();

    public IReadOnlyList<OrderLine> OrderLines => _orderLines;

    public bool IsPaid { get; private set; }

    public string Date { get; }


    public Order(int id, Customer customer, string date)
    {
        Id = id;
        Customer = customer;
        Date = date;
    }


    public void AddOrderLine(OrderLine orderLine)
    {
        if (IsPaid)
        {
            Console.WriteLine(
                "ERROR: cannot change a paid order."
            );

            return;
        }

        if (orderLine.Quantity <= 0)
        {
            Console.WriteLine(
                "ERROR: quantity must be positive."
            );

            return;
        }

        if (orderLine.Product.Stock < orderLine.Quantity)
        {
            Console.WriteLine(
                $"ERROR: not enough stock for product #{orderLine.Product.Id}."
            );

            return;
        }

        orderLine.Product.Stock -= orderLine.Quantity;

        _orderLines.Add(orderLine);
    }


    public void Pay()
    {
        if (_orderLines.Count == 0)
        {
            Console.WriteLine(
                "ERROR: cannot pay an empty order."
            );

            return;
        }

        IsPaid = true;
    }


    public decimal CalculateTotal()
    {
        decimal total = 0;

        foreach (OrderLine line in _orderLines)
        {
            total += line.Product.Price * line.Quantity;
        }

        if (Customer.IsVip)
        {
            total *= 0.90m;
        }

        return total;
    }
}