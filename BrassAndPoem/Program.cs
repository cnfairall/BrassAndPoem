
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Serialization;

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Last Word",
        Price = 12.00M,
        ProductTypeId = 0
    },

    new Product()
    {
        Name = "Corpse Reviver",
        Price = 15.00M,
        ProductTypeId = 1
    },

    new Product()
    {
        Name = "Paper Plane",
        Price = 13.00M,
        ProductTypeId = 0
    },

    new Product()
    {
        Name = "Black Manhattan",
        Price = 20.00M,
        ProductTypeId = 1
    },

    new Product()
    {
        Name = "Negroni",
        Price = 10.00M,
        ProductTypeId = 0
    }
};

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Title = "Brass",
        Id = 0
    },

    new ProductType()
    {
        Title = "Poem",
        Id = 1
    }
};

List<string> typeTitles = productTypes.Select(t => t.Title).ToList();

Console.WriteLine("Welcome to Brass and Poem!");
DisplayMenu();
void DisplayMenu()
{
    string choice = null;
    while (choice != "5")
    {
    Console.WriteLine(@"Please select a number from the menu below
        1. Display all products
        2. Delete a product
        3. Add a new product
        4. Update product properties
        5. Exit");

        choice = (Console.ReadLine().Trim());

        if (choice == "1")
        {
            DisplayAllProducts(products, productTypes);
        }
        else if (choice == "2")
        {
            DeleteProduct(products, productTypes, typeTitles);
        }
        else if (choice == "3")
        {
            AddProduct(products, productTypes);

        }
        else if (choice == "4")
        {
            UpdateProduct(products, productTypes);
        }
        else if (choice == "5")
        {
            Console.WriteLine("Goodbye");
        }
        else
        {
            Console.WriteLine("Please select a valid option");
        }
    }
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}, {products[i].Price} dollars, {typeTitles[products[i].ProductTypeId]} ");
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes, List<string> typeTitles)
{
    Product chosenProduct = null;
    int response = 0;

    while (chosenProduct == null)
    {
        Console.WriteLine("Please select number beside item you want to delete");
        

        DisplayAllProducts(products, productTypes);
        try
        {
            response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers.");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only.");
        }
    }

    Console.WriteLine(@$"You chose:
    {chosenProduct.Name}, {chosenProduct.Price} dollars, {typeTitles[chosenProduct.ProductTypeId]}");

    string choice = null;

    Console.WriteLine(@"Choose an option:
    0. Cancel
    1. Confirm delete");

    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Delete cancelled");
    }
    else if (choice == "1")
    {
        products.Remove(chosenProduct);

    }

}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine(@"Please enter new product in this format:
    'name, price' ");

    string[] response = (Console.ReadLine()).Split(",");
    string newName = response[0];
    decimal newPrice = Convert.ToDecimal(response[1]);

    Console.WriteLine(@"Please select product type:
    0. Brass
    1. Poem");

    int newType = int.Parse(Console.ReadLine());

    Product newProduct = new Product
    {
        Name = newName,
        Price = newPrice,
        ProductTypeId = newType

    };

    products.Add(newProduct);

    Console.WriteLine($"You added: {newProduct.Name}, {newProduct.Price}, {typeTitles[newProduct.ProductTypeId]}");

}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    string newName = null;
    decimal newPrice = 0;
    int newTypeId = 0;


    Console.WriteLine("Please select product to update:");

    DisplayAllProducts(products, productTypes);

    Product chosenProduct = null;

    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: ");
        try
        {
            int choice = int.Parse(Console.ReadLine().Trim());

            chosenProduct = products[choice - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
    }

    Console.WriteLine(@$"You chose:
    {chosenProduct.Name}, {chosenProduct.Price} dollars, and {typeTitles[chosenProduct.ProductTypeId]}");

    Console.WriteLine("Please enter new name. If no change is needed, press enter");

    string response = (Console.ReadLine().Trim());
    if (String.IsNullOrWhiteSpace(response) == false)
    {
        newName = response;
        chosenProduct.Name = newName;
    }

    Console.WriteLine("Please enter new price. If no change is needed, press enter");

    response = (Console.ReadLine().Trim());
    if (String.IsNullOrWhiteSpace(response) == false)
    {
        newPrice = Convert.ToDecimal(response);
        chosenProduct.Price = newPrice;
    }

    Console.WriteLine(@"Please enter new product type. Select
    0 for Brass
    1 for Poem
    If no change is needed, press enter");

    response = (Console.ReadLine().Trim());
    if (String.IsNullOrWhiteSpace(response) == false)
    {
        newTypeId = int.Parse(response);
        chosenProduct.ProductTypeId = newTypeId;
    }

    Console.WriteLine(@$"You updated your product to read:
    {chosenProduct.Name}, {chosenProduct.Price} dollars, {typeTitles[chosenProduct.ProductTypeId]}");
}

// don't move or change this!
public partial class Program { }