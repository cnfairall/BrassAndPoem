
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
        Console.WriteLine($"{i + 1}. {products[i].Name}, {products[i].Price}, {typeTitles[products[i].ProductTypeId]} ");
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
    {chosenProduct.Name}, {chosenProduct.Price}, {typeTitles[chosenProduct.ProductTypeId]}");

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
        products.RemoveAt(response - 1);

    }

}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

// don't move or change this!
public partial class Program { }