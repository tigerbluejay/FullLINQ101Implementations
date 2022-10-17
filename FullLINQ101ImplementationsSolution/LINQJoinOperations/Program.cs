using LINQJoinOperations.Models;


////////////////////////////////
////////// Cross Join
////////////////////////////////

string[] categories = {
                "Beverages",
                "Condiments",
                "Vegetables",
                "Dairy Products",
                "Seafood"
            };

List<Product> products = GetProductList();

var query = from category in categories
            join product in products on category equals product.Category
            select (Category: category, product.ProductName);

foreach (var value in query)
{
    Console.WriteLine(value.ProductName + ": " + value.Category);
}
Console.ReadKey(); 

List<Product> GetProductList()
{
    var products = new List<Product>() {
        new Product { ProductName = "Coke", Category = "Beverages"},
        new Product { ProductName = "Water", Category = "Beverages" },
        new Product { ProductName = "Sushi", Category = "Seafood" },
        new Product { ProductName = "Paella", Category = "Seafood" },
        new Product { ProductName = "Milk", Category = "Dairy Products" },
        new Product { ProductName = "Linden", Category = "Teas" },
        new Product { ProductName = "Chamomile", Category = "Teas" }
    };

    return products;
}



////////////////////////////////
//////////// Group Join
////////////////////////////////

string[] categories2 = {
                "Beverages",
                "Condiments",
                "Vegetables",
                "Dairy Products",
                "Seafood"
            };

List<Product> products2 = GetProductList();

var query2 = from category in categories2
             join product in products2 on category equals product.Category into ps
             select (Category: category, Products: ps);

foreach (var value in query2)
{
    Console.WriteLine(value.Category + ":");
    foreach (var product in value.Products)
    {
        Console.WriteLine("   " + product.ProductName);
    }
}
Console.ReadKey();


////////////////////////////////
/// Cross Join with Group Join
////////////////////////////////

string[] categories3 = {
                "Beverages",
                "Condiments",
                "Vegetables",
                "Dairy Products",
                "Seafood"
            };

List<Product> products3 = GetProductList();

var query3 = from category in categories3
             join product in products3 on category equals product.Category into ps
             from product in ps
             select (Category: category, product.ProductName);

foreach (var value in query3)
{
    Console.WriteLine(value.ProductName + ": " + value.Category);
}
Console.ReadKey();


/////////////////////////////////////
/// Left Outer Join using Group Join
/////////////////////////////////////

string[] categories4 = {
                "Beverages",
                "Condiments",
                "Vegetables",
                "Dairy Products",
                "Seafood"
            };

List<Product> products4 = GetProductList();

var query4 = from category in categories4
        join product in products4 on category equals product.Category into ps
        from product in ps.DefaultIfEmpty()
        select (Category: category, ProductName: product == null ? "(No products)" : product.ProductName);

foreach (var value in query4)
{
    Console.WriteLine($"{value.ProductName}: {value.Category}");
}
Console.ReadKey();
