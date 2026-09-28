using Part1_ProceduralToOOP;

OrderSystem system = new OrderSystem();


// Sample Customers
system.AddCustomer(
    new Customer(1, "Mona Ali", "mona@example.com", "Cairo", true)
);

system.AddCustomer(
    new Customer(2, "Omar Hassan", "omar@example.com", "Alexandria", false)
);

system.AddCustomer(
    new Customer(3, "Sara Nabil", "sara@example.com", "Giza", false)
);


// Sample Products
system.AddProduct(
    new Product(101, 50.0m, 100, "USB Cable")
);

system.AddProduct(
    new Product(102, 250.0m, 40, "Wireless Mouse")
);

system.AddProduct(
    new Product(103, 1200.0m, 15, "Mechanical Keyboard")
);

system.AddProduct(
    new Product(104, 400.0m, 25, "Laptop Stand")
);


// Demo Scenario

Order order1 = new Order(
    1001,
    system.GetCustomerById(1)!,
    "2026-09-15"
);

order1.AddOrderLine(
    new OrderLine(system.GetProductById(101)!, 2)
);

order1.AddOrderLine(
    new OrderLine(system.GetProductById(102)!, 1)
);

system.AddOrder(order1);

order1.Pay();


Order order2 = new Order(
    1002,
    system.GetCustomerById(2)!,
    "2026-09-15"
);

order2.AddOrderLine(
    new OrderLine(system.GetProductById(103)!, 1)
);

order2.AddOrderLine(
    new OrderLine(system.GetProductById(104)!, 1)
);

system.AddOrder(order2);


Order order3 = new Order(
    1003,
    system.GetCustomerById(3)!,
    "2026-09-16"
);

order3.AddOrderLine(
    new OrderLine(system.GetProductById(101)!, 5)
);

system.AddOrder(order3);

order3.Pay();


// Menu

int choice = -1;

while (choice != 0)
{
    Console.WriteLine("\n---------- MENU ----------");
    Console.WriteLine("1) Print customers");
    Console.WriteLine("2) Print products");
    Console.WriteLine("3) Print all orders");
    Console.WriteLine("4) Print one order by id");
    Console.WriteLine("5) Create order");
    Console.WriteLine("6) Add line to order");
    Console.WriteLine("7) Mark order paid");
    Console.WriteLine("8) Show paid sales total");
    Console.WriteLine("0) Exit");
    Console.Write("Choice: ");

    choice = int.Parse(Console.ReadLine());

    if (choice == 1)
    {
        system.PrintCustomers();
    }
    else if (choice == 2)
    {
        system.PrintProducts();
    }
    else if (choice == 3)
    {
        system.PrintAllOrders();
    }
    else if (choice == 4)
    {
        Console.Write("Order id: ");
        int orderId = int.Parse(Console.ReadLine());

        system.PrintOrder(orderId);
    }
    else if (choice == 5)
    {
        Console.Write("Order id: ");
        int orderId = int.Parse(Console.ReadLine());

        Console.Write("Customer id: ");
        int customerId = int.Parse(Console.ReadLine());

        Console.Write("Date (YYYY-MM-DD): ");
        string date = Console.ReadLine();

        Customer? customer = system.GetCustomerById(customerId);

        if (customer == null)
        {
            Console.WriteLine(
                $"ERROR: customer id {customerId} not found."
            );
            continue;
        }

        Order order = new Order(orderId, customer, date);

        system.AddOrder(order);
    }
    else if (choice == 6)
    {
        Console.Write("Order id: ");
        int orderId = int.Parse(Console.ReadLine());

        Console.Write("Product id: ");
        int productId = int.Parse(Console.ReadLine());

        Console.Write("Quantity: ");
        int quantity = int.Parse(Console.ReadLine());

        Order? order = system.GetOrderById(orderId);
        Product? product = system.GetProductById(productId);

        if (order == null)
        {
            Console.WriteLine(
                $"ERROR: order id {orderId} not found."
            );
            continue;
        }

        if (product == null)
        {
            Console.WriteLine(
                $"ERROR: product id {productId} not found."
            );
            continue;
        }

        order.AddOrderLine(
            new OrderLine(product, quantity)
        );
    }
    else if (choice == 7)
    {
        Console.Write("Order id: ");
        int orderId = int.Parse(Console.ReadLine());

        Order? order = system.GetOrderById(orderId);

        if (order == null)
        {
            Console.WriteLine(
                $"ERROR: order id {orderId} not found."
            );
            continue;
        }

        order.Pay();
    }
    else if (choice == 8)
    {
        Console.WriteLine(
            $"Paid sales total: {system.CalculateTotalSales():F2}"
        );
    }
    else if (choice == 0)
    {
        Console.WriteLine("Bye.");
    }
    else
    {
        Console.WriteLine("Unknown choice.");
    }
}