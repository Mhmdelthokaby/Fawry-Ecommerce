
using Fawry_Ecommerce.Entites;
using Fawry_Ecommerce.Entites.Cart_Aggregate;
using Fawry_Ecommerce.Entites.Products;
using Fawry_Ecommerce.Services;

var cheese = new ExpirableShippableProduct("Cheese", 100, 5, DateTime.Now.AddDays(1), 0.2);
var biscuits = new ExpirableShippableProduct("Biscuits", 150, 3, DateTime.Now.AddDays(1), 0.7);
var tv = new ShippableProduct("TV", 300, 2, 5);
var scratchCard = new SimpleProduct("ScratchCard", 50, 10);

var products = new List<Product> { cheese, biscuits, tv, scratchCard };


Console.WriteLine("--------------Welcome--------------");
Console.WriteLine("-----------FawryEcommerce----------");
Console.WriteLine("");

Console.WriteLine("Add Your Name :");
string name = Console.ReadLine();

Console.WriteLine("Add your Balance: ");
if (!double.TryParse(Console.ReadLine(), out double balance))
{
    Console.WriteLine("Invalid balance input. Exiting...");
    return;
}

var customer = new Customer(name, balance);
var cart = new Cart();
while (true)
{
    Console.WriteLine("****************************");

    Console.WriteLine("\nChoose an option:");
    Console.WriteLine("1. Add Product to Cart");
    Console.WriteLine("2. Checkout");
    Console.WriteLine("3. Exit");

    var choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.WriteLine("****************************");

        Console.WriteLine("\nAvailable Products:");
        for (int i = 0; i < products.Count; i++)
        {
            var p = products[i];
            Console.WriteLine($"{i + 1}. {p.Name} - Price: {p.Price}, Available: {p.Quantity}");
        }

        Console.Write("Select Product (1-4): ");
        if (!int.TryParse(Console.ReadLine(), out int prodIndex) || prodIndex < 1 || prodIndex > products.Count)
        {
            Console.WriteLine("Invalid product selection.");
            continue;
        }

        Product selectedProduct = products[prodIndex - 1];

        Console.Write($"Enter quantity for {selectedProduct.Name}: ");
        if (!int.TryParse(Console.ReadLine(), out int qty) || qty < 1)
        {
            Console.WriteLine("Invalid quantity.");
            continue;
        }

        try
        {
            cart.Add(selectedProduct, qty);
            Console.WriteLine($"{qty}x {selectedProduct.Name} added to cart.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    else if (choice == "2")
    {
        try
        {
            CheckoutService.Checkout(customer, cart);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Checkout failed: {ex.Message}");
        }
        break;
    }
    else if (choice == "3")
    {
        Console.WriteLine("Exiting. Goodbye!");
        break;
    }
    else
    {
        Console.WriteLine("Invalid option. Try again.");
    }

}