namespace Part1_ProceduralToOOP;

public class OrderSystem
{
    private List<Customer> Customers = new();
    private List<Product> Products = new();
    private List<Order> Orders = new();


    // =========================
    // Customers
    // =========================

    public void AddCustomer(Customer customer)
    {
        if (GetCustomerById(customer.Id) != null)
        {
            Console.WriteLine(
                $"ERROR: customer id {customer.Id} already exists."
            );

            return;
        }

        Customers.Add(customer);
    }

    public Customer? GetCustomerById(int id)
    {
        foreach (Customer customer in Customers)
        {
            if (customer.Id == id)
            {
                return customer;
            }
        }

        return null;
    }

    public void PrintCustomers()
    {
        Console.WriteLine("\n=== CUSTOMERS ===");

        foreach (Customer customer in Customers)
        {
            Console.WriteLine(
                $"#{customer.Id} | {customer.Name} | {customer.Email} | {customer.City} | VIP: {customer.IsVip}"
            );
        }
    }


    // =========================
    // Products
    // =========================

    public void AddProduct(Product product)
    {
        if (GetProductById(product.Id) != null)
        {
            Console.WriteLine(
                $"ERROR: product id {product.Id} already exists."
            );

            return;
        }

        Products.Add(product);
    }

    public Product? GetProductById(int id)
    {
        foreach (Product product in Products)
        {
            if (product.Id == id)
            {
                return product;
            }
        }

        return null;
    }

    public void PrintProducts()
    {
        Console.WriteLine("\n=== PRODUCTS ===");

        foreach (Product product in Products)
        {
            Console.WriteLine(
                $"#{product.Id} | {product.Name} | Price: {product.Price:F2} | Stock: {product.Stock}"
            );
        }
    }


    // =========================
    // Orders
    // =========================

    public void AddOrder(Order order)
    {
        if (GetOrderById(order.Id) != null)
        {
            Console.WriteLine(
                $"ERROR: order id {order.Id} already exists."
            );

            return;
        }

        if (GetCustomerById(order.Customer.Id) == null)
        {
            Console.WriteLine(
                $"ERROR: customer id {order.Customer.Id} not found."
            );

            return;
        }

        Orders.Add(order);
    }

    public Order? GetOrderById(int id)
    {
        foreach (Order order in Orders)
        {
            if (order.Id == id)
            {
                return order;
            }
        }

        return null;
    }


    // =========================
    // Print Orders
    // =========================

    public void PrintOrder(int id)
    {
        Order? order = GetOrderById(id);

        if (order == null)
        {
            Console.WriteLine(
                $"ERROR: order id {id} not found."
            );

            return;
        }

        Console.WriteLine($"\n=== ORDER #{order.Id} ===");

        Console.WriteLine(
            $"Date: {order.Date}"
        );

        Console.WriteLine(
            $"Customer: #{order.Customer.Id} - {order.Customer.Name}"
        );

        Console.WriteLine(
            $"Paid: {order.IsPaid}"
        );

        Console.WriteLine("Lines:");

        foreach (OrderLine line in order.OrderLines)
        {
            decimal lineTotal =
                line.Product.Price * line.Quantity;

            Console.WriteLine(
                $"  {line.Product.Name} | Qty: {line.Quantity} | Price: {line.Product.Price:F2} | Total: {lineTotal:F2}"
            );
        }

        Console.WriteLine(
            $"TOTAL: {order.CalculateTotal():F2}"
        );
    }


    public void PrintAllOrders()
    {
        Console.WriteLine("\n=== ALL ORDERS ===");

        foreach (Order order in Orders)
        {
            PrintOrder(order.Id);
        }
    }


    // =========================
    // Sales
    // =========================

    public decimal CalculateTotalSales()
    {
        decimal total = 0;

        foreach (Order order in Orders)
        {
            if (order.IsPaid)
            {
                total += order.CalculateTotal();
            }
        }

        return total;
    }
}