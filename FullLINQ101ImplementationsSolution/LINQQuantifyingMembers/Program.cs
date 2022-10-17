using LINQQuantifyingMembers.Models;


////////////////////////////////////////////////
///////// Check for any matching elements
////////////////////////////////////////////////

string[] words = { "believe", "relief", "receipt", "field" };

bool iAfterE = words.Any(word => word.Contains("ei"));

Console.WriteLine($"There is a word in the list that contains 'ei': {iAfterE}");
Console.ReadKey();


/////////////////////////////////////////////////////////
///////// Group by any elements matching a condition
/////////////////////////////////////////////////////////

List<Product> products = GetProductList();
var productGroups = from product in products
                    group product by product.Category into g
                    where g.Any(product => product.UnitsInStock == 0)
                    select (Category: g.Key, Products: g);

foreach (var group in productGroups)
{
    Console.WriteLine(group.Category);
    foreach (var product in group.Products)
    {
        Console.WriteLine($"\t{product}");
    }
}
Console.ReadKey();

List<Product> GetProductList()
{
    var productsList = new List<Product>();
    Product product1 = new Product() { Category = "Tools", UnitsInStock = 0 };
    Product product2 = new Product() { Category = "Appliances", UnitsInStock = 3 };
    Product product3 = new Product() { Category = "Bedding", UnitsInStock = 6 };
    Product product4 = new Product() { Category = "Decoration", UnitsInStock = 5 };
    Product product5 = new Product() { Category = "Utilities", UnitsInStock = 1 };
    productsList.Add(product1); productsList.Add(product2); productsList.Add(product3);
    productsList.Add(product4); productsList.Add(product5);
    return productsList;
}



////////////////////////////////////////////////////////
///////// Check that all the elements match a condition
////////////////////////////////////////////////////////

int[] numbers = { 1, 11, 3, 19, 41, 65, 19 };

bool onlyOdd = numbers.All(number => number % 2 == 1);

Console.WriteLine($"The list contains only odd numbers: {onlyOdd}");
Console.ReadKey();


/////////////////////////////////////////////////////
///////// Group by all elements matching a condition
/////////////////////////////////////////////////////

List<Product> products2 = GetProductList();

var productGroups2 = from product in products2
                    group product by product.Category into g
                    where g.All(product => product.UnitsInStock > 0)
                    select (Category: g.Key, Products: g);

foreach (var group in productGroups2)
{
    Console.WriteLine(group.Category);
    foreach (var product in group.Products)
    {
        Console.WriteLine($"\t{product}");
    }
}
Console.ReadKey();