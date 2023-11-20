using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, Product> products = new Dictionary<string, Product>();
    static int totalSales = 0;
    static decimal totalRevenue = 0;

    static void Main()
    {   //welcome messege
        Console.WriteLine("Welcome to the Inventory Management System!");

        //check username and password
        static bool userpass()
        {
            Console.Write("Please enter your username: ");
            string user = Console.ReadLine();
            Console.Write("Please enter your password: ");
            string pass = Console.ReadLine();

            // Simple authentication 
            return (user == "admin" && pass == "adminpass");
        }

        // User Authentication
        if (!userpass())
        {
            Console.WriteLine("Authentication failed. Exiting...");
            return;
        }

        while (true)
        {
            Console.WriteLine("\nAuthentication successful! Welcome, admin! ");
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Add a new product");
            Console.WriteLine("2. Update product quantity");
            Console.WriteLine("3. Display product list");
            Console.WriteLine("4. Record sale");
            Console.WriteLine("5. Generate product report");
            Console.WriteLine("6. Generate sales report");
            Console.WriteLine("7. Exit");

            Console.Write("Select an operation (1-7): ");
            string choice = Console.ReadLine();

            //switch to select from the list
            switch (choice)
            {
                case "1":
                    Add();
                    break;
                case "2":
                    Update();
                    break;
                case "3":
                    Display();
                    break;
                case "4":
                    Record();
                    break;
                case "5":
                    ProductR();
                    break;
                case "6":
                    SaleR();
                    break;
                case "7":
                    Console.WriteLine("Thank you for using the Inventory Management System, admin!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid operation.");
                    break;
            }
        }
    }




    static void Add()
    {
        // Prompt the user to enter the product name
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();

        // Check if the product already exists in the 'products' dictionary
        if (products.ContainsKey(name))
        {
            // If the product exists, inform the user and exit the method
            Console.WriteLine("Product already exists. Use 'Update product quantity' to add more stock.");
            return;
        }

        // If the product doesn't exist, prompt the user to enter the product price
        Console.Write("Enter product price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        // Prompt the user to enter the initial quantity of the product
        Console.Write("Enter initial quantity: ");
        int quantity = int.Parse(Console.ReadLine());

        // Create a new Product object with the entered price and quantity
        // Add the product to the 'products' dictionary with the product name as the key
        products[name] = new Product { Price = price, Quantity = quantity };

        // Inform the user that the product has been added successfully
        Console.WriteLine("Product added successfully!");
    }

    static void Update()
    {
        // Prompt the user to enter the product name
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();

        // Check if the product exists in the 'products' dictionary
        if (!products.ContainsKey(name))
        {
            // If the product is not found, inform the user and exit the method
            Console.WriteLine("Product not found.");
            return;
        }

        // Prompt the user to enter the quantity to add to the existing quantity
        Console.Write("Enter quantity to add: ");
        int quantityToAdd = int.Parse(Console.ReadLine());

        // Update the quantity of the existing product in the 'products' dictionary
        products[name].Quantity += quantityToAdd;

        // Inform the user that the quantity has been updated successfully
        Console.WriteLine("Quantity updated successfully!");
    }


    static void Display()
    {
        // Display a header indicating that the following list is the Product List
        Console.WriteLine("Product List:");

        // Initialize an index for numbering the products in the list
        int index = 1;

        // Iterate through each key-value pair in the 'products' dictionary
        foreach (var product in products)
        {
            // Display the product information along with its index, name, price, and quantity
            Console.WriteLine($"{index}. {product.Key} - Price: ${product.Value.Price}, Quantity: {product.Value.Quantity}");

            // Increment the index for the next product
            index++;
        }
    }


    static void Record()
    {
        // Prompt the user to enter the product name for recording a sale
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();

        // Check if the product exists in the 'products' dictionary
        if (!products.ContainsKey(name))
        {
            // If the product is not found, inform the user and exit the method
            Console.WriteLine("Product not found.");
            return;
        }

        // Prompt the user to enter the quantity of the product sold
        Console.Write("Enter quantity sold: ");
        int quantitySold = int.Parse(Console.ReadLine());

        // Check if there is enough stock available for the product
        if (quantitySold > products[name].Quantity)
        {
            // If there is not enough stock, inform the user and exit the method
            Console.WriteLine("Not enough stock available for this product.");
            return;
        }

        // Update the quantity of the sold product in the 'products' dictionary
        products[name].Quantity -= quantitySold;

        // Update the total sales and total revenue based on the sale
        totalSales += quantitySold;
        totalRevenue += quantitySold * products[name].Price;

        // Inform the user that the sale has been recorded successfully
        Console.WriteLine("Sale recorded successfully!");
    }


    static void ProductR()
    {
        // Display a header indicating that the following list is the Product Report
        Console.WriteLine("Product Report:");

        // Iterate through each key-value pair in the 'products' dictionary
        foreach (var product in products)
        {
            // Display the product name and quantity in the report
            Console.WriteLine($"{product.Key} - Quantity: {product.Value.Quantity}");
        }
    }


    static void SaleR()
    {
        // Display a header indicating that the following information is the Sales Report
        Console.WriteLine("Sales Report:");

        // Display the total number of sales
        Console.WriteLine($"Total Sales: {totalSales}");

        // Display the total revenue from all sales
        Console.WriteLine($"Total Revenue: ${totalRevenue}");
    }

}

class Product
{
    // Property to store the price of the product
    public decimal Price { get; set; }

    // Property to store the quantity of the product
    public int Quantity { get; set; }
}