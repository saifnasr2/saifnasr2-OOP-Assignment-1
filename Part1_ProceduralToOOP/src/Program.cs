namespace Part1_ProceduralToOOP;

class Program
{
    static List<Customer> customers = new();
    static List<Product> products = new();
    static List<Order> orders = new();


    static void Main(string[] args)
    {
        var customer = new Customer(
            1,
            "Saif",
            "saif@example.com",
            "Mansoura",
            true);

        AddCustomer(customer);

        var product = new Product(
            1,
            "Mouse",
            500,
            10);

        AddProduct(product);

        var order = CreateOrder(1, customer.Id);

        order.AddLine(product, 2);

        Console.WriteLine($"Order Total: {order.CalculateTotal()}");

        order.Pay();

        Console.WriteLine($"Order Paid: {order.IsPaid}");
        Console.WriteLine($"Total Sales: {CalculateTotalSales()}");


        RunInteractiveMenu();
    }

    static Customer? FindCustomerById(int id)
    {
        foreach (var customer in customers)
        {
            if (customer.Id == id)
                return customer;
        }

        return null;
    }

    static Product? FindProductById(int id)
    {
        foreach (var product in products)
        {
            if (product.Id == id)
                return product;
        }

        return null;
    }

    static Order? FindOrderById(int id)
    {
        foreach (var order in orders)
        {
            if (order.Id == id)
                return order;
        }

        return null;
    }

    static void AddCustomer(Customer customer)
    {
        foreach (var existingCustomer in customers)
        {
            if (existingCustomer.Id == customer.Id)
                throw new InvalidOperationException("Customer ID already exists.");
        }

        customers.Add(customer);
    }

    static void AddProduct(Product product)
    {
        foreach (var existingProduct in products)
        {
            if (existingProduct.Id == product.Id)
                throw new InvalidOperationException("Product ID already exists.");
        }

        products.Add(product);
    }
       
    static Order CreateOrder(int id, int customerId)
    {
        foreach (var existingOrder in orders)
        {
            if (existingOrder.Id == id)
                throw new InvalidOperationException("Order ID already exists.");
         }

        Customer customer = null;

        foreach (var existingCustomer in customers)
        {
            if (existingCustomer.Id == customerId)
            {
                customer = existingCustomer;
                break;
            }
        }

        if (customer == null)
            throw new InvalidOperationException("Customer does not exist.");

        var order = new Order(id, customer, DateTime.Now);

        orders.Add(order);

        return order;
    }

    static decimal CalculateTotalSales()
    {
        decimal total = 0;

        foreach (var order in orders)
        {
            if (order.IsPaid)
                total += order.CalculateTotal();
        }

        return total;
    }

    static void PrintMenu()
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
    }
  
    static void RunInteractiveMenu()
    {
        while (true)
        {
            PrintMenu();

            string? choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        PrintCustomers();
                        break;

                    case "2":
                        PrintProducts();
                        break;

                    case "3":
                        PrintOrders();
                        break;

                    case "4":
                        PrintOrder();
                        break;

                    case "5":
                        CreateOrder();
                        break;

                    case "6":
                        AddLineToOrder();
                        break;

                    case "7":
                        PayOrder();
                        break;

                    case "8":
                        Console.WriteLine(
                            $"Paid Sales Total = {TotalSalesPaidOnly()}");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static void PrintCustomers()
    {
        Console.WriteLine("\n--- CUSTOMERS ---");

        foreach (var customer in customers)
        {
            Console.WriteLine(
                $"ID={customer.Id}, " +
                $"Name={customer.Name}, " +
                $"Email={customer.Email}, " +
                $"City={customer.City}, " +
                $"VIP={customer.IsVip}");
        }
    }
 
    static void PrintProducts()
    {
        Console.WriteLine("\n--- PRODUCTS ---");

        foreach (var product in products)
        {
            Console.WriteLine(
                $"ID={product.Id}, " +
                $"Name={product.Name}, " +
                $"Price={product.Price}, " +
                $"Stock={product.Stock}");
        }
    }

    static void CreateOrder()
    {
        Console.Write("Order ID: ");
        int orderId = int.Parse(Console.ReadLine()!);

        Console.Write("Customer ID: ");
        int customerId = int.Parse(Console.ReadLine()!);

        if (FindOrderById(orderId) != null)
        {
            Console.WriteLine("Order ID already exists.");
            return;
        }

        Customer? customer = FindCustomerById(customerId);

        if (customer == null)
        {
            Console.WriteLine("Customer not found.");
            return;
        }

        Order order = new Order(
            orderId,
            customer,
            DateTime.Now);

        orders.Add(order);

        Console.WriteLine("Order created successfully.");
    }

    static void AddLineToOrder()
    {
        Console.Write("Order ID: ");
        int orderId = int.Parse(Console.ReadLine()!);

        Console.Write("Product ID: ");
        int productId = int.Parse(Console.ReadLine()!);

        Console.Write("Quantity: ");
        int quantity = int.Parse(Console.ReadLine()!);

        Order? order = FindOrderById(orderId);

        if (order == null)
        {
            Console.WriteLine("Order not found.");
            return;
        }

        Product? product = FindProductById(productId);

        if (product == null)
        {
            Console.WriteLine("Product not found.");
            return;
        }

        try
        {
            order.AddLine(product, quantity);
            Console.WriteLine("Line added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void PayOrder()
    {
        Console.Write("Order ID: ");
        int orderId = int.Parse(Console.ReadLine()!);

        Order? order = FindOrderById(orderId);

        if (order == null)
        {
            Console.WriteLine("Order not found.");
            return;
        }

        try
        {
            order.Pay();
            Console.WriteLine("Order marked as paid.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void PrintOrderDetails(Order order)
    {
        Console.WriteLine($"\n--- ORDER {order.Id} ---");
        Console.WriteLine($"Customer: {order.Customer.Name}");
        Console.WriteLine($"Date: {order.Date}");
        Console.WriteLine($"Paid: {order.IsPaid}");

        foreach (var line in order.OrderLines)
        {
            Console.WriteLine(
                $"  Product={line.Product.Name}, " +
                $"Quantity={line.Quantity}, " +
                $"Price={line.Product.Price}");
        }

        Console.WriteLine($"Total: {order.CalculateTotal()}");
    }
   
    static void PrintOrders()
    {
        foreach (var order in orders)
        {
            PrintOrderDetails(order);
        }
    }

    static void PrintOrder()
    {
        Console.Write("Order ID: ");
        int orderId = int.Parse(Console.ReadLine()!);

        Order? order = FindOrderById(orderId);

        if (order == null)
        {
            Console.WriteLine("Order not found.");
            return;
        }

        PrintOrderDetails(order);
    }

    static decimal TotalSalesPaidOnly()
    {
        decimal total = 0;

        foreach (var order in orders)
        {
            if (order.IsPaid)
            {
                total += order.CalculateTotal();
            }
        }

        return total;
    }

}
