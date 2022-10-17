using FullLINQ101Implementations.Classes;


///////////////////////////////////////////
// Your First LINQ Query //////////////////
///////////////////////////////////////////

int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

var lowNumbers = from number in numbers
                 where number < 5
                 select number;

Console.WriteLine("Numbers < 5:");
foreach (var x in lowNumbers)
{
    Console.WriteLine(x);
}
Console.ReadKey();


///////////////////////////////////////////
// Filter Elements on a Property  /////////
///////////////////////////////////////////

List<Product> products = GetProductList();

var soldOutProducts = from product in products
                      where product.UnitsInStock == 0
                      select product;

Console.WriteLine("Sold out products:");
foreach (var soldOutProduct in soldOutProducts)
{
    Console.WriteLine($"{soldOutProduct.ProductName} is sold out!");
}
Console.ReadKey();

List<Product> GetProductList()
{
    List<Product> productsList = new List<Product>();
    productsList.Add(new Product { ProductName = "Product 1", UnitsInStock = 3, UnitPrice = 3.00m });
    productsList.Add(new Product { ProductName = "Product 2", UnitsInStock = 0, UnitPrice = 4.00m });
    productsList.Add(new Product { ProductName = "Product 3", UnitsInStock = 5, UnitPrice = 6.00m });
    productsList.Add(new Product { ProductName = "Product 4", UnitsInStock = 1, UnitPrice = 1.00m });
    productsList.Add(new Product { ProductName = "Product 5", UnitsInStock = 0, UnitPrice = 2.00m });
    productsList.Add(new Product { ProductName = "Product 6", UnitsInStock = 2, UnitPrice = 1.00m });
    productsList.Add(new Product { ProductName = "Product 7", UnitsInStock = 0, UnitPrice = 7.00m });
    productsList.Add(new Product { ProductName = "Product 8", UnitsInStock = 3, UnitPrice = 8.00m });


    return productsList;
}



///////////////////////////////////////////
// Filter elements on multiple properties
///////////////////////////////////////////

List<Product> products2 = GetProductList();

var expensiveInStockProducts = from product in products2
                               where product.UnitsInStock > 0 && product.UnitPrice > 3.00M
                               select product;

Console.WriteLine("In-stock products that cost more than 3.00:");
foreach (var expensiveInStockProduct in expensiveInStockProducts)
{
    Console.WriteLine($"{expensiveInStockProduct.ProductName} is in stock and costs more than 3.00.");
}
Console.ReadKey();


//////////////////////////////////////////////////
// Examine a Sequence Property of Output Elements
/////////////////////////////////////////////////

List<Customer> customers = GetCustomerList();

var waCustomers = from customer in customers
                  where customer.Region == "WA"
                  select customer;

Console.WriteLine("Customers from Washington and their orders:");
foreach (var wacustomer in waCustomers)
{
    Console.WriteLine($"Customer {wacustomer.CustomerID}: {wacustomer.CompanyName}");
    foreach (var wacustomerOrder in wacustomer.Orders)
    {
        Console.WriteLine($"  Order {wacustomerOrder.OrderID}: {wacustomerOrder.OrderDate}");
    }
}
Console.ReadKey();

List<Customer> GetCustomerList()
{
    List<Customer> customerList = new List<Customer>()
    {
        new Customer() { CustomerID = 1, CompanyName="Nintendo", Region="WA",
            Orders = new List<Order>() { new Order() { OrderID = 1, OrderDate = DateTime.Now },
                                         new Order() { OrderID = 2, OrderDate = DateTime.Now },
                                         new Order() { OrderID = 3, OrderDate = DateTime.Today},
                                         new Order() { OrderID = 4, OrderDate = DateTime.Today}
                                        }
                       },
        new Customer() { CustomerID = 2, CompanyName="Sony", Region="CA",
            Orders = new List<Order>() { new Order() { OrderID = 5, OrderDate = DateTime.Now },
                                         new Order() { OrderID = 6, OrderDate = DateTime.Now },
                                         new Order() { OrderID = 7, OrderDate = DateTime.Today},
                                         new Order() { OrderID = 8, OrderDate = DateTime.Today}
                                        }
                        },
        new Customer() { CustomerID = 3, CompanyName="Sega", Region="WA",
            Orders = new List<Order>() { new Order() { OrderID = 9, OrderDate = DateTime.Now },
                                         new Order() { OrderID = 10, OrderDate = DateTime.Now },
                                         new Order() { OrderID = 11, OrderDate = DateTime.Today},
                                         new Order() { OrderID = 12, OrderDate = DateTime.Today}
                                        }
                       }

    };
    return customerList;
}



///////////////////////////////////////////
// Filter elements based on position
///////////////////////////////////////////

string[] digits = { "zero", "one", "two", "three", "four", "five", "six", 
    "seven", "eight", "nine" };

var shortDigits = digits.Where((digit, index) => digit.Length < index);

Console.WriteLine("Short digits:");
foreach (var shortDigit in shortDigits)
{
    Console.WriteLine($"The word {shortDigit} is shorter than its value.");
}
Console.ReadKey();