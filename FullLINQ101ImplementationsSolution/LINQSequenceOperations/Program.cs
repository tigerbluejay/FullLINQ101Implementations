using LINQSequenceOperations.Models;


//////////////////////////////////////////////
//////// Compare two sequences for equality
//////////////////////////////////////////////

var wordsA = new string[] { "cherry", "apple", "blueberry" };
var wordsB = new string[] { "cherry", "apple", "blueberry" };

bool match = wordsA.SequenceEqual(wordsB);

Console.WriteLine($"The sequences match: {match}");
Console.ReadKey();


//////////////////////////////////////
//////// Concatenate two Sequences
//////////////////////////////////////

int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
int[] numbersB = { 1, 3, 5, 7, 8 };

var allNumbers = numbersA.Concat(numbersB);

Console.WriteLine("All numbers from both arrays:");
foreach (var n in allNumbers)
{
    Console.WriteLine(n);
}
Console.ReadKey();


////////////////////////////////////////////////////
//////// Concatenate Projections from Two Sequences
////////////////////////////////////////////////////

List<Customer> customers = GetCustomerList();
List<Product> products = GetProductList();

//var customerNames = from customer in customers
//                    select customer.CompanyName;
//var productNames = from product in products
//                   select product.ProductName;

var customerNames = customers.Select(customer => customer.CompanyName);
var productNames = products.Select(product => product.ProductName);

var allNames = customerNames.Concat(productNames);

Console.WriteLine("Customer and product names:");
foreach (var name in allNames)
{
    Console.WriteLine(name);
}
Console.ReadKey();

List<Customer> GetCustomerList()
{
    List<Customer> customerList = new List<Customer>() { new Customer { CompanyName = "Texaco" },
                                                     new Customer { CompanyName = "McDonalds"},
                                                     new Customer { CompanyName = "Avada"} };
    return customerList;
}

List<Product> GetProductList()
{
    List<Product> productList = new List<Product>() { new Product { ProductName = "Oil" },
                                                     new Product { ProductName = "Food" },
                                                     new Product { ProductName = "Design"} };
    return productList;
}



//////////////////////////////////////
//////// Combine sequences with Zip
//////////////////////////////////////

int[] vectorA = { 0, 2, 4, 5, 6 };
int[] vectorB = { 1, 3, 5, 7, 8 };

int dotProduct = vectorA.Zip(vectorB, (a, b) => a * b).Sum();

Console.WriteLine($"Dot product: {dotProduct}");
Console.ReadKey();